
using System.Threading.Tasks;
using WesternApparel.Core.ViewModels;

namespace WesternApparel.Core.ServiceContracts
{
    public interface IBrowseService
    {
        Task<BrowseViewModel> FetchBrowsePageProductsAsync( string category, int pageSize, int currentPage );
    }
}
