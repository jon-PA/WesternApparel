using System.Collections.Generic;

namespace WesternApparel.Core.ViewModels
{
    public class ProductViewModel : BaseLayoutViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string DisplayPrice { get; set; }

        /// <summary>
        /// Value may include markup. Ensure script and other hazardous tags are removed before serving.
        /// </summary>
        public string ProductShortDescription { get; set; }
        public string ProductFullDescription { get; set; }

        public string ThumbnailURL { get; set; }

        public List<CrumbAnchor> CrumbsList { get; set; }
    }

    public class CrumbAnchor
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public CrumbAnchor( )
        { }

        public CrumbAnchor( string name, string url )
        {
            this.Name = name;
            this.Url = url;
        }
    }
}
