using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using WesternApparel.Core.Requests;
using WesternApparel.Core.ServiceContracts;
using WesternApparel.Core.ViewModels;

namespace WesternApparel.Data.Dapper
{
    public class CatalogRepository : ICatalogRepository
    {
        readonly IDbConnection Connection;

        public CatalogRepository( IDbConnection connection )
        {
            this.Connection = connection;
        }

        public async Task<BrowseViewModel> FetchBrowsePageProductsAsync( BrowseViewRequest request )
        {
            var pageOffset = request.PageSize * (request.Page - 1);

            var category = $"{request.Category ?? string.Empty}%";

            using var reader = await Connection.QueryMultipleAsync(
                @"SELECT COUNT(*) AS TotalRecordCount FROM Products;
                  SELECT 
                    ID AS ProductID, 
                    Name as ProductName, 
                    CONCAT('$', Convert(varchar, Price, 1)) AS DisplayPrice, 
                    ThumbnailURL
                  FROM Products
                  WHERE Category LIKE @Category
                  ORDER BY ID
                  OFFSET @PageOffset ROWS FETCH NEXT @PageSize ROWS ONLY;",

                new { 
                    PageSize = request.PageSize, 
                    PageOffset = pageOffset,
                    Category = category
                }
            );

            var totalRecords = reader.ReadSingle<int>( );
            var products     = (await reader.ReadAsync<ProductPreviewItem>( false )).ToList( );

            return new BrowseViewModel
            {
                TotalPages = (int) System.Math.Ceiling( (float) totalRecords / request.PageSize ),
                Products = products,
                CurrentPage = request.Page,
            };
        }
    }
}