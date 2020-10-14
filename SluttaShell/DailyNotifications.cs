using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using SluttaShell.Services;

namespace SluttaShell
{
    // Spec wanted us to enqueue a ton of notifications. We cant enqueue more than 50 on android so we are going
    // to have to enqueue some and then enqueue more later. As this is local there arent great times to do this.
    // We can do it on opening the app, but dont want to hammer the service too frequently so we say that if two days
    // have passed we'll re-enqueue. This isn't satisfying (is anything in mobile dev? :P) but there is no way that
    // there would MAX_NOTIF_COUNT notifications in two days.
    // Of course this means if the app isn't opened for any of the 48 notifications then the next batch won't get
    // enqueue and the notifications will stop. Also not ideal but maybe there is solace is knowing that if the app
    // is not opened for that long then it probably wasn't being used anyway.
    // We'll see. This is another tower of compromises, but gets us moving.
    //
    // Expected behavior:
    // - For each day schedule notifications evenly across the time range 9am to 9pm inclusive.
    // - Interleave notifications from smoke and/or snus sources depending on what the user has enabled, taking user
    //   settings on reason for quitting into account.
    public static class DailyNotifications
    {
        // opted a little lower than 50. Picked then and never changed it, feel free to tweak
        const int MAX_NOTIF_COUNT = 48;

        public static List<UxNotifs> PastSmokeNotifs;
        public static List<UxNotifs> PastSnusNotifs;

        static readonly TimeSpan _reEnqueueFrequency = TimeSpan.FromDays(2);
        static DateTime _lastEnqueue = DateTime.MinValue;
        static TimeSpan TimeSinceLastEnqueue => DateTime.UtcNow - _lastEnqueue;

        static int WeekdaysFree(DateTime since) => (int)((DateTime.Today - since.Date).TotalDays);

        //------------------------------------------------------------

        public static void UpdateEnqueuedLocalNotifications()
        {
            if (TimeSinceLastEnqueue < _reEnqueueFrequency)
            {
                return;
            }
            ForceUpdateEnqueuedLocalNotifications();
        }

        public static void ForceUpdateEnqueuedLocalNotifications()
        {
            DependencyService.Get<INotificationManager>().CancelPendingNotifications();

            var userData = StoffService.GetStoff();
            var smokeData = userData[0];
            var snusData = userData[1];

            var smokeDay = 999;
            var snusDay = 999;

            string quitSmokeReason = null;
            string quitSnusReason = null;

            if (smokeData.IsActive)
            {
                smokeDay = WeekdaysFree(smokeData.QuitDateTime);
                quitSmokeReason = smokeData.Grunn;
            }

            if (snusData.IsActive)
            {
                snusDay = WeekdaysFree(snusData.QuitDateTime);
                quitSnusReason = snusData.Grunn;
            }

            var listOfEachDaysNotifications = GetNotificationsAfterGivenDay(smokeDay,
                                                                            snusDay,
                                                                            DailyNotificationMessages.LocalNotifsSmoke,
                                                                            DailyNotificationMessages.LocalNotifsSnus,
                                                                            quitSmokeReason,
                                                                            quitSnusReason);
            Enqueue(listOfEachDaysNotifications, MAX_NOTIF_COUNT);

            _lastEnqueue = DateTime.UtcNow;
        }

        //------------------------------------------------------------

        static void Enqueue(List<ADaysNotifs> daysNotifs, int maxCount)
        {
            var notificationMgr = DependencyService.Get<INotificationManager>();
            var midnightAmTodayLocal = DateTime.Today;
            var totalCount = 0;
            foreach (var theDaysNotifs in daysNotifs)
            {
                if (totalCount >= maxCount)
                {
                    return;
                }
                var midnightAmNotifDay = midnightAmTodayLocal + TimeSpan.FromDays(theDaysNotifs.NumberOfDaysFromToday);

                foreach (var notif in theDaysNotifs.Notifs)
                {
                    if (totalCount >= maxCount)
                    {
                        return;
                    }
                    var notifTime = midnightAmNotifDay + notif.Time;
                    if (notifTime > DateTime.Now)
                    {
                        notificationMgr.Later(notifTime, "Slutta", notif.Message, true, 0);
                        totalCount += 1;
                    }
                }
            }
        }

        //------------------------------------------------------------

        public static List<ADaysNotifs> GetNotificationsAfterGivenDay(int startDayA,
                                                                      int startDayB,
                                                                      Dictionary<int, Dictionary<string, string[]>> notifsA,
                                                                      Dictionary<int, Dictionary<string, string[]>> notifsB,
                                                                      string reasonA,
                                                                      string reasonB)
        {
            var results = new List<ADaysNotifs>();
            var relativeDayFromNow = 0;
            var dayA = startDayA;
            var dayB = startDayB;

            while (dayA <= 365 || dayB <= 365)
            {
                var potentialsA = notifsA.GetValueOrDefault(dayA, new Dictionary<string, string[]>());
                var potentialsB = notifsB.GetValueOrDefault(dayB, new Dictionary<string, string[]>());

                var mandatoryA = potentialsA.GetValueOrDefault("MANDATORY", new string[0]);
                var mandatoryB = potentialsB.GetValueOrDefault("MANDATORY", new string[0]);

                var reasonedA = potentialsA.GetValueOrDefault(reasonA, new string[0]);
                var reasonedB = potentialsB.GetValueOrDefault(reasonB, new string[0]);

                var dayNotifsA = InterleaveArrays(mandatoryA, reasonedA);
                var dayNotifsB = InterleaveArrays(mandatoryB, reasonedB);

                var taggedNotifsA = dayNotifsA
                    .Select((x, i) => new TaggedMessage(x, TaggedMessage.Tag.A, zero: (dayA == 0 && i == 0))).ToList();
                var taggedNotifsB = dayNotifsB
                    .Select((x, i) => new TaggedMessage(x, TaggedMessage.Tag.B, zero: (dayB == 0 && i == 0))).ToList();

                var daysNotifs = InterleaveArrays(taggedNotifsA, taggedNotifsB);

                var notifHour = 9.0;
                var timeStep = daysNotifs.Count > 0 ? (12.0 / (daysNotifs.Count - 1)) : 0.0;

                if (daysNotifs.Count > 0)
                {
                    foreach (var elem in daysNotifs)
                    {
                        elem.Time = TimeSpan.FromHours(notifHour);
                        notifHour += timeStep;
                    }
                    results.Add(new ADaysNotifs() {
                            NumberOfDaysFromToday = relativeDayFromNow,
                            Notifs = daysNotifs
                        });
                }
                relativeDayFromNow += 1;
                dayA += 1;
                dayB += 1;
            }

            return results;
        }

        static List<T> InterleaveArrays<T>(IReadOnlyList<T> a, IReadOnlyList<T> b)
        {
            var interleaved = new List<T>();
            var aLen = a.Count;
            var bLen = b.Count;
            var minLen = Math.Min(aLen, bLen);
            var maxLen = Math.Max(aLen, bLen);
            var longer = (aLen > bLen) ? a : b;
            for (var i = 0; i < minLen; i++)
            {
                interleaved.Add(a[i]);
                interleaved.Add(b[i]);
            }
            for (var i = minLen; i < maxLen; i++)
            {
                interleaved.Add(longer[i]);
            }
            return interleaved;
        }

        //------------------------------------------------------------

        public static void UpdatePastNotifs()
        {
            var userData = StoffService.GetStoff();
            var smokeData = userData[0];
            var snusData = userData[1];

            var smokeNotifs = new List<UxNotifs>();
            var snusNotifs = new List<UxNotifs>();

            var smokeDay = smokeData.IsActive ? 0 : 999;
            var snusDay = snusData.IsActive ? 0 : 999;

            var smokeMidnightAmStartDateTime = smokeData.IsActive ? smokeData.QuitDate : DateTime.MinValue;
            var snusMidnightAmStartDateTime = snusData.IsActive ? snusData.QuitDate : DateTime.MinValue;

            if (smokeData.IsActive && snusData.IsActive)
            {
                smokeDay = WeekdaysFree(smokeData.QuitDateTime);
                snusDay = WeekdaysFree(snusData.QuitDateTime);
                var startMax = Math.Max(smokeDay, snusDay);
                smokeDay -= startMax;
                snusDay -= startMax;
            }

            var listOfEachDaysNotifications = GetNotificationsAfterGivenDay(smokeDay,
                                                                            snusDay,
                                                                            DailyNotificationMessages.LocalNotifsSmoke,
                                                                            DailyNotificationMessages.LocalNotifsSnus,
                                                                            smokeData.Grunn,
                                                                            snusData.Grunn);

            foreach (var dayNotifs in listOfEachDaysNotifications)
            {
                var smokeDayNotifs = new List<string>();
                var snusDayNotifs = new List<string>();
                var relDayNum = dayNotifs.NumberOfDaysFromToday;

                foreach (var notif in dayNotifs.Notifs)
                {
                    if (notif.Tagged == TaggedMessage.Tag.A)
                    {
                        var dayNumA = smokeDay + relDayNum;
                        var notifTimeA = smokeMidnightAmStartDateTime + TimeSpan.FromDays(dayNumA) + notif.Time;
                        var msgInPastA = notifTimeA < DateTime.Now;
                        var afterStartA = notifTimeA > smokeData.QuitDateTime;
                        if ((notif.Zero && dayNumA == 0 && smokeMidnightAmStartDateTime < DateTime.Now) || (msgInPastA && afterStartA))
                        {
                            smokeDayNotifs.Add(notif.Message);
                        }
                    }
                    else if (notif.Tagged == TaggedMessage.Tag.B)
                    {
                        var dayNumB = snusDay + relDayNum;
                        var notifTimeB = snusMidnightAmStartDateTime + TimeSpan.FromDays(dayNumB) + notif.Time;
                        var msgInPastB = notifTimeB < DateTime.Now;
                        var afterStartB = notifTimeB > snusData.QuitDateTime;
                        if ((notif.Zero && dayNumB == 0 && snusMidnightAmStartDateTime < DateTime.Now) || (msgInPastB && afterStartB))
                        {
                            snusDayNotifs.Add(notif.Message);
                        }
                    }
                }

                if (smokeDayNotifs.Count > 0)
                {
                    var formatted = string.Join("\n\n", smokeDayNotifs);
                    smokeNotifs.Add(new UxNotifs() {
                            Day = smokeDay + relDayNum,
                            Messages = formatted
                    });
                }
                if (snusDayNotifs.Count > 0)
                {
                    var formatted = string.Join("\n\n", snusDayNotifs);
                    snusNotifs.Add(new UxNotifs() {
                            Day = snusDay + relDayNum,
                            Messages = formatted
                    });
                }
            }

            smokeNotifs.Reverse();
            snusNotifs.Reverse();
            PastSmokeNotifs = smokeNotifs;
            PastSnusNotifs = snusNotifs;
        }


        //------------------------------------------------------------

        static V GetValueOrDefault<K, V>(this Dictionary<K,V> dict, K key, V valueIfMissing = default)
        {
            if (!typeof(K).IsValueType && ReferenceEquals(key, null))
            {
                return valueIfMissing;
            }
            else if (dict.TryGetValue(key, out var res))
            {
                return res;
            }
            else
            {
                return valueIfMissing;
            }
        }
    }

    public class TaggedMessage
    {
        public enum Tag { A, B }

        public readonly string Message;
        public readonly Tag Tagged;
        public readonly bool Zero;
        public TimeSpan Time;

        public TaggedMessage(string msg, Tag tag, bool zero)
        {
            Message = msg;
            Tagged = tag;
            Zero = zero;
        }
    }

    public class ADaysNotifs
    {
        public int NumberOfDaysFromToday;
        public List<TaggedMessage> Notifs;
    }

    public class UxNotifs
    {
        public int Day { get; set; }
        public string DayPretty => $"Dag {Day}";
        public string Messages { get; set; }
    }
}
