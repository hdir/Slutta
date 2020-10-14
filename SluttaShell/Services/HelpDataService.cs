using System.Reflection;
using System.IO;
using Newtonsoft.Json;

namespace SluttaShell.Services
{
    public static class HelpDataService
    {

        public static HelpData GetHelp()
        {
            var assembly = typeof(HelpDataService).GetTypeInfo().Assembly;

            Stream stream = assembly.GetManifestResourceStream("SluttaShell.HelpDataDefaults.json");

            var json = "";
            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<HelpData>(json);
        }
    }
}
