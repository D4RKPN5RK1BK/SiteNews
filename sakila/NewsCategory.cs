using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SiteNews.sakila
{
    public partial class NewsCategory
    {
        [Key]
        public int NewsCategoryId { get; set; }
        public string NewsCategoryName { get; set; }
    }
}
