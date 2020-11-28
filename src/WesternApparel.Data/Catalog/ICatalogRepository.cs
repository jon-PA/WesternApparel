using System.Threading.Tasks;

namespace WesternApparel.Core.Catalog
{
    public interface ICatalogRepository
    {
        Task<BrowseViewModel> FetchBrowsePageProductsAsync( BrowseViewRequest request );
    }
}