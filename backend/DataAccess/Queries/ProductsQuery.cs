namespace DataAccess.Queries
{
    public class ProductsQuery {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        public string SearchQuery { get; set; } = string.Empty;

        public int[] CategoryIds { get; set; } = [];
        public int[] BrandIds { get; set; } = [];
    };
}
