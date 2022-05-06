namespace SiteNews.DisplayModels {
    public class PageModel {
        public int CurrentPage;
        public int FirstPage;
        public int LastPage;
        public int TotalCount;
        public int PageSize;

        public PageModel() {
            CurrentPage = 1;
            FirstPage = 1;
            LastPage = 1;
            TotalCount = 0;
            PageSize = 0;
        }

        public PageModel(int count, int current = 1, int size = 20) {
            PageSize = size;
            TotalCount = count;
            CurrentPage = current;
            FirstPage = 1;
            LastPage = (int)MathF.Ceiling(count / size);
        }

        public bool HavePreviousPage { get => CurrentPage > FirstPage; }
        public bool HaveNextPage { get => CurrentPage < LastPage; }

        public int SkipTo() {
            return (CurrentPage - 1) * PageSize;
        }
    }
}