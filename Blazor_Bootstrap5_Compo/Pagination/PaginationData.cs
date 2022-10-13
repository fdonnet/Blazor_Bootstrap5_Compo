namespace Blazor_Bootstrap5_Compo.Pagination
{
    public class PaginationData
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages
        {
            get
            {
                int remainder;
                int quotient = Math.DivRem(TotalCount, PageSize, out remainder);
                return remainder == 0 ? quotient : quotient + 1;
            }
        }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public int Skip => (CurrentPage - 1) * PageSize;
    }
}

