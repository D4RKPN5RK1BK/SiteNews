namespace SiteNews.DisplayModels {
    public class PageModel {
        public int CurrentPage;
        public int FirstPage;
        public int LastPage;
        public int TotalCount;
        public int PageSize;

        public PageModel() {
            CurrentPage = 0;
            FirstPage = 1;
            LastPage = 1;
            TotalCount = 0;
            PageSize = 0;
        }

        public PageModel(int size, int count, int current) {
            PageSize = size;
            TotalCount = count;
            CurrentPage = current;
            FirstPage = 1;
            LastPage = (int)MathF.Ceiling(count / size);
        }

        public bool HavePreviousPage() => CurrentPage > FirstPage;
        public bool HaveNextPage() => CurrentPage < LastPage;

        public int Skip() {
            return 1;
        }
    }
}