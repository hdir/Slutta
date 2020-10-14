using System.Collections.Generic;
using Xamarin.Forms.Internals;

namespace SluttaShell.Services
{
    [Preserve(AllMembers = true)]
    public class HelpData
    {
        public List<Tips> TipsList
        {
            get;
            set;
        }
        public List<HelpTools> HelpToolsList
        {
            get;
            set;
        }
    }
}
