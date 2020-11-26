
using System.Threading.Tasks;
using WesternApparel.Core.Requests;
using WesternApparel.Core.ViewModels;

namespace WesternApparel.Core.ServiceContracts
{
    public interface ICatalogRepository
    {
        Task<BrowseViewModel> FetchBrowsePageProductsAsync( BrowseViewRequest request );
    }
}
