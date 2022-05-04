using SiteNews.sakila;

namespace SiteNews.FilterModels
{
    public class NewsFilterModel
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Category { get; set;}
        public Func<News, bool> FilterPredicate = (News n) =>  { return true; };
    }
}
