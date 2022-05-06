using SiteNews.FilterModels;
using SiteNews.sakila;
using SiteNews.SortModels;
using SiteNews.DisplayModels;

namespace SiteNews.ViewModels
{
    public class NewsViewModel
    {
        public NewsSortModel Sort;
        public NewsFilterModel Filter;
        public PageModel Display;
        public List<News> Elements;
    }
}
