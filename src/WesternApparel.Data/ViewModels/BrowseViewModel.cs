using System.Collections.Generic;

namespace WesternApparel.Core.ViewModels
{
    public class BrowseViewModel : BaseLayoutViewModel
    {
        public List<ProductPreviewItem> Products { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string Category { get; set; }
    }

    public class ProductPreviewItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public string DisplayPrice { get; set; }

        public string ThumbnailURL { get; set; }
    }
}
