using System;
using System.Collections.Generic;

#nullable disable

namespace SiteNews.sakila
{
    public partial class ReceptionAdm
    {
        public short IdReception { get; set; }
        public DateTime DataObr { get; set; }
        public TimeSpan TimeObr { get; set; }
        public int NumObr { get; set; }
        public string FioF { get; set; }
        public string FioI { get; set; }
        public string FioO { get; set; }
        public string Adr { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Sfera { get; set; }
        public string Text { get; set; }
        public string Fulnamefile { get; set; }
    }
}
