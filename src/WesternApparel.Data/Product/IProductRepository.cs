using System.Threading.Tasks;
using WesternApparel.Core.Cart;

namespace WesternApparel.Core.Product
{
    public interface IProductRepository
    {
        Task<ProductViewModel> FetchProductPageDataAsync( int productID );

        /// <summary>
        ///     Given a product ID, produces a new CartItem with the relevant fields filled out
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        Task<CartItem> FillCartItemInfo( int productID );
    }
}