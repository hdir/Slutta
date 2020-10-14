using System.Collections.Generic;
using System;
using Xamarin.Forms.Internals;

namespace SluttaShell.Services
{
    [Preserve(AllMembers = true)]
    public class BadgeInfo
    {
        public List<Badge> BadgeInfoRoyk { get; set; }
        public List<Badge> BadgeInfoSnus { get; set; }

        public static BadgeInfo GetFiltered(BadgeInfo unfilteredInfo, List<Stoff> stoffList)
        {
            var smokeQuitDateTime = stoffList[0].QuitDateTime;
            var snusQuitDateTime = stoffList[1].QuitDateTime;
            return new BadgeInfo()
            {
                BadgeInfoRoyk = stoffList[0].IsActive ? Filter(unfilteredInfo.BadgeInfoRoyk, smokeQuitDateTime) : new List<Badge>(),
                BadgeInfoSnus = stoffList[1].IsActive ? Filter(unfilteredInfo.BadgeInfoSnus, snusQuitDateTime) : new List<Badge>()
            };
        }

        static List<Badge> Filter(IReadOnlyList<Badge> unfilteredBadges, DateTime quitDateTime)
        {
            var results = new List<Badge>(unfilteredBadges.Count);

            foreach (var badge in unfilteredBadges)
            {
                if (badge.IsInPast(quitDateTime))
                {
                    badge.IsActive = true;
                    results.Add(badge);
                }
                else
                {
                    break;
                }
            }

            if (results.Count < unfilteredBadges.Count)
            {
                var nextBadge = unfilteredBadges[results.Count];
                nextBadge.ImageUrlProcessed = nextBadge.imageurlempty;
                nextBadge.IsActive = false;
                results.Add(nextBadge);
            }

            return results;
        }
    }
}
