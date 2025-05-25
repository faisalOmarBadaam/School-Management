using Microsoft.EntityFrameworkCore;

namespace SchoolProject.Core.Helpers
{
    public class PageList<T>
    {
        public List<T> Items { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public bool HasNextPage { get; set; }

        public bool HasPreviosPage { get; set; }

        private PageList(List<T> items, int Page, int PageSize, int TotalCount)
        {
            this.Items = items;
            this.Page = Page;
            this.PageSize = PageSize;
            this.TotalCount = TotalCount;
            HasNextPage = TotalCount > this.Page * this.PageSize;
            HasPreviosPage = Page > 1;

        }

        public static async Task<PageList<T>> CreateAsync(IQueryable<T> query, int page, int pageSize)
        {
            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PageList<T>(items, page, pageSize, totalCount);
        }


    }
}
