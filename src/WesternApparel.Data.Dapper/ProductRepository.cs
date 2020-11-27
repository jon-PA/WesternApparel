using System.Data;
using System.Threading.Tasks;
using Dapper;
using WesternApparel.Core.ServiceContracts;
using WesternApparel.Core.ViewModels;

namespace WesternApparel.Data.Dapper
{
    public class ProductRepository : IProductRepository
    {
        readonly IDbConnection Connection;

        public ProductRepository( IDbConnection connection )
        {
            this.Connection = connection;
        }

        public async Task<ProductViewModel> FetchProductPageDataAsync( int productID )
        {
            var vm = await Connection.QuerySingleOrDefaultAsync<ProductViewModel>(
                @"SELECT
                    ID AS ProductID, 
                    Name as Title, 
                    Name as ProductName, 
                    Category as Category,
                    CONCAT('$', Convert(varchar, Price, 1)) AS DisplayPrice, 
                    ShortDescription AS ProductShortDescription,
                    LongDescription AS ProductFullDescription,
                    ThumbnailURL
                  FROM Products
                  WHERE ListingBrowsable = 1 AND ID = @ProductID",

                new
                {
                    ProductID = productID,
                }
            );

            return vm;
        }
    }
}