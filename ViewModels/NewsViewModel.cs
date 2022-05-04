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
        public PageModel Page;
        public List<News> Elements;
    }
}
