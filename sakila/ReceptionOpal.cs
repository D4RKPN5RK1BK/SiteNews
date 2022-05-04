using System;
using System.Collections.Generic;

#nullable disable

namespace SiteNews.sakila
{
    public partial class ReceptionOpal
    {
        public short IdReception { get; set; }
        public DateTime DataObr { get; set; }
        public TimeSpan TimeObr { get; set; }
        public int NumObr { get; set; }
        public string Email { get; set; }
        public string Sfera { get; set; }
        public string Text { get; set; }
        public string Fulnamefile { get; set; }
    }
}
