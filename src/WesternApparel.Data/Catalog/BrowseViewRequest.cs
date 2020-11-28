namespace WesternApparel.Core.Catalog
{
    public class BrowseViewRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Category { get; set; }
    }
}