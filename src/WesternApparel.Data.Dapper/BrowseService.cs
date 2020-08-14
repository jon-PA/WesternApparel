using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using WesternApparel.Core.ServiceContracts;
using WesternApparel.Core.ViewModels;

namespace WesternApparel.Data.Dapper
{
    public class BrowseService : IBrowseService
    {
        readonly DbConnection Connection;

        public BrowseService( DbConnection connection )
        {
            this.Connection = connection;
        }

        public async Task<BrowseViewModel> FetchBrowsePageProductsAsync( string category, int pageSize, int currentPage )
        {
            var pageOffset = pageSize * (currentPage - 1);

            using var reader = await Connection.QueryMultipleAsync(
                @"SELECT COUNT(*) AS TotalRecordCount FROM Products;
                  SELECT 
                    ID AS ProductID, 
                    Name as ProductName, 
                    CONCAT('$', Convert(varchar, Price, 1)) AS DisplayPrice, 
                    ThumbnailURL
                  FROM Products 
                  ORDER BY ID
                  OFFSET @PageOffset ROWS FETCH NEXT @PageSize ROWS ONLY;",

                new { 
                    PageSize = pageSize, 
                    PageOffset = pageOffset 
                }
            );

            var totalRecords = reader.ReadSingle<int>( );
            var products     = (await reader.ReadAsync<ProductPreviewItem>( false )).ToList( );

            return new BrowseViewModel
            {
                TotalPages = (int) System.Math.Ceiling( (float) totalRecords / pageSize ),
                Products = products,
                CurrentPage = currentPage,
            };
        }
    }
}