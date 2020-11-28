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
        /// <summary>
        /// Given a product ID, produces a new CartItem with the relevant fields filled out
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        Task<CartItem> FillCartItemInfo( int productID );
    }
}
