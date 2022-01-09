namespace Api.SeedWork
{
    public class PaginationQueryParams
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public string Sort {get; set;}
    }
}