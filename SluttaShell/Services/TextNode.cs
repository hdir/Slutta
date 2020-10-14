using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SluttaShell.Services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    // constructed from json
    public class TextNode
    {
        public string Title { get; set; }
        public string Innertext { get; set; }
        public List<string> Listitems { get; set; }
        public List<string> DottedListitems { get; set; }
        public List<string> NumberedListitems { get; set; }
        public string Linktext { get; set; }
        public string Linkurl { get; set; }
        public bool External { get; set; }
        [JsonIgnore] public bool Internal => !External;
        public string Img { get; set; }
    }
}
