using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WesternApparel.Core.ViewModels;

namespace WesternApparel.Core.ServiceContracts
{
    public interface IProductRepository
    {
        Task<ProductViewModel> FetchProductPageDataAsync( int productID );
    }
}
