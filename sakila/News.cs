using System;
using System.Collections.Generic;

#nullable disable

namespace SiteNews.sakila
{
    public partial class News
    {
        public short IdNews { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataTime { get; set; }
        public int NameCategory { get; set; }
        public string NameShort { get; set; }
        public string NameLong { get; set; }
        public string Text { get; set; }
        public string Mark { get; set; }
        public int Public { get; set; }
    }
}
