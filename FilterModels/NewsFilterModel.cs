using SiteNews.sakila;

namespace SiteNews.FilterModels
{
    public class NewsFilterModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? CategoryId { get; set;}
        public Func<News, bool> FilterPredicate;

        
        public NewsFilterModel() {
            FilterPredicate = DefaultFilter;
        }

        public bool DefaultFilter(News element) {
            
            if (Id != null && Id > 0 && element.IdNews != Id)
                return false;

            if(!String.IsNullOrEmpty(Name) && element.NameLong != Name)
                return false;

            if (CategoryId != null && CategoryId > 0 && element.NameCategory != CategoryId)
                return false;

            return true;
        }

    }
}
