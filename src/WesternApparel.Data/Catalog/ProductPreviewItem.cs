namespace WesternApparel.Core.Catalog
{
    /// <summary>
    ///     A class representing a single product grid preview on the Browse page
    /// </summary>
    public class ProductPreviewItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public string DisplayPrice { get; set; }

        public string ThumbnailURL { get; set; }
    }
}