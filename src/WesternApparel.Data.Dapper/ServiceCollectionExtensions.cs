using System;
using System.Data.Common;
using Microsoft.Extensions.DependencyInjection;
using WesternApparel.Core.ServiceContracts;

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
        public static IServiceCollection AddWADapperServices( this IServiceCollection services, Func<IServiceProvider, DbConnection> connectionFactory )
        {
            services.AddScoped<DbConnection>( connectionFactory );
            services.AddScoped<IBrowseService, BrowseService>( );
            services.AddScoped<IProductService, ProductService>( );

            return services;
        }
    }
}
