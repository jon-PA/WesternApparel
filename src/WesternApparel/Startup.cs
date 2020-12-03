using System;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WesternApparel.Core.Cart;
using WesternApparel.Data.Dapper;
using WesternApparel.Services;

namespace WesternApparel
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private static DbConnection CreateDbConnection( IServiceProvider serviceProvider )
        {
            var config = serviceProvider.GetRequiredService<IConfiguration>( );

            return new SqlConnection( config["WesternApparelDBConnection"] );
        }

        public void ConfigureServices( IServiceCollection services )
        {
            services.AddDistributedMemoryCache( );

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(6);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews( )
                .AddRazorRuntimeCompilation( )
                ;


            services.AddAuthentication( CookieAuthenticationDefaults.AuthenticationScheme )
                .AddCookie( options =>
                {
                    options.LoginPath = "/account/register";
                    options.LogoutPath = "/account/logout";
                } );

            services.AddWADapperServices( CreateDbConnection );
            services.AddHttpContextAccessor( );
            services.AddScoped<ICartService, SessionCartService>( );
            services.AddRouting( options => options.LowercaseUrls = true );
        }

        public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if( env.IsDevelopment( ) )
            {
                app.UseDeveloperExceptionPage( );
            }
            else
            {
                app.UseExceptionHandler( "/Home/Error" );
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts( );
            }
            app.UseHttpsRedirection( );
            app.UseStaticFiles( );

            app.UseRouting( );

            app.UseAuthentication( );
            app.UseAuthorization( );

            app.UseSession( );
            
            app.UseEndpoints( endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Landing}/{action=Index}/{id?}" );
            } );
        }
    }
}
