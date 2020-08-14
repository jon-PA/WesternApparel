using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WesternApparel.Core.ViewModels;

namespace WesternApparel.Core.ServiceContracts
{
    public interface IProductService
    {
        Task<ProductViewModel> FetchProductPageDataAsync( int productID );
    }
}
