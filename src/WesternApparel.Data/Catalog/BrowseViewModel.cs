using System.Collections.Generic;
using WesternApparel.Core.Common;

namespace WesternApparel.Core.Catalog
{
    public class BrowseViewModel : BaseLayoutViewModel
    {
        public BrowseViewModel( ) : base( "Shop" )
        { }

        public List<ProductPreviewItem> Products { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string Category { get; set; }
    }
}