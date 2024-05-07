using Core.Models;

namespace ECommerceServerSide.Helpers.Pagination
{

    public class Pagination<T> where T : class
    {
        public Pagination(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = count;
            CountLeft = TotalCount - (PageIndex * PageSize) > 0 ? TotalCount - (PageIndex * pageSize) : 0;
            Data = data;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int CountLeft { get; set; }
        public int TotalCount { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
