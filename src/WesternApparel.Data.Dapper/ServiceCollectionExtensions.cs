using System;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
using WesternApparel.Core.Catalog;
using WesternApparel.Core.Product;

namespace WesternApparel.Data.Dapper
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers implementations for <see cref="WesternApparel.Core.ServiceContracts"/> implementations using Dapper
        /// </summary>
        /// <param name="services">The service collection to register the services to</param>
        /// <param name="connectionFactory">Factory that creates the DBConnection used by Dapper. If it is supported by dapper, it should work here.</param>
        /// <returns></returns>
        public static IServiceCollection AddWADapperServices( this IServiceCollection services, Func<IServiceProvider, IDbConnection> connectionFactory )
        {
            services.AddScoped<IDbConnection>( connectionFactory );
            services.AddScoped<ICatalogRepository, CatalogRepository>( );
            services.AddScoped<IProductRepository, ProductRepository>( );

            return services;
        }
    }
}
