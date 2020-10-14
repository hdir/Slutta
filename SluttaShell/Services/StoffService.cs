using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

namespace SluttaShell.Services
{
    public static class StoffService
    {
        const string STOFF_FILE_NAME = "stoffDataFile.txt";

        public static string StoffFilePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), STOFF_FILE_NAME);

        // Note:
        // Even though there are only ever two elements, we use a list as we know Xamarin's carousel view (and co)
        // will work with this. We could wrap this up in an object but Xamarin is temperamental enough already
        public static List<Stoff> GetStoff()
        {
            var json = "";
            var assembly = typeof(StoffService).GetTypeInfo().Assembly;
            var filePath = StoffFilePath;

            List<Stoff> result = null;

            // choose the correct stream
            if (File.Exists(filePath))
            {
                json = File.ReadAllText(filePath);
                result = JsonConvert.DeserializeObject<List<Stoff>>(json);
            }

            if (result == null)
            {
                // choose the correct stream
                Stream stream = assembly.GetManifestResourceStream("SluttaShell.Defaults.json");

                using (var reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }
                result = JsonConvert.DeserializeObject<List<Stoff>>(json);
                foreach (var stoffElem in result)
                {
                    stoffElem.QuitDateTime = DateTime.Now;
                }
            }

            // a bit goofy, but we can assume both entries exist by now
            result[0].Kind = StoffKind.Smoke;
            result[1].Kind = StoffKind.Snus;

            return result;
        }
    }
}
