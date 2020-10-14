using System;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

namespace SluttaShell.Services
{
    public static class BadgeService
    {
        public static BadgeInfo GetBadges()
        {
            var assembly = typeof(BadgeService).GetTypeInfo().Assembly;

            var stream = assembly.GetManifestResourceStream("SluttaShell.BadgeInfo.json");

            using (var reader = new StreamReader(stream))
            {
                var foo = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BadgeInfo>(foo);
            }
        }
    }
}
