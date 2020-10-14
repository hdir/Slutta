using System.Collections.Generic;
using Firebase.Analytics;
using Foundation;
using SluttaShell.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(EventTrackerIOS))]
namespace SluttaShell.iOS
{
    public class EventTrackerIOS : IEventTracker
    {
        public void SendEvent(string eventId) => SendEvent(eventId, null);

        public void SendEvent(string eventId, string paramName, string value) =>
            SendEvent(eventId, new Dictionary<string, string> { { paramName, value } });

        public void SendEvent(string eventId, IDictionary<string, string> parameters)
        {
            if (parameters == null)
            {
                Analytics.LogEvent(eventId, (Dictionary<object, object>)null);
                return;
            }

            // unzip to nsstrings
            var keys = new List<NSString>();
            var values = new List<NSString>();
            foreach (var (key, value) in parameters)
            {
                keys.Add(new NSString(key));
                values.Add(new NSString(value));
            }

            var parametersDictionary =
                NSDictionary<NSString, NSObject>.FromObjectsAndKeys(values.ToArray(), keys.ToArray(), keys.Count);

            Analytics.LogEvent(eventId, parametersDictionary);
        }
    }
}
