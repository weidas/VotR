using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.Framework.DependencyInjection;
using System;
using Microsoft.AspNet.Diagnostics.Entity;

namespace VotR.Web
{
    public class Startup
    {
        // This method gets called by the runtime.
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            // Add EF services to the services container.
            services.AddEntityFramework(Configuration)
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>();
            */
            // Add Identity services to the services container.
            //services.AddDefaultIdentity<ApplicationDbContext, ApplicationUser, IdentityRole>(Configuration);

            // Add MVC services to the services container.
            services.AddMvc();

            //services.AddTransient<TodoList.Services.StatisticsService>();

        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app)
        {
            // Add the following to the request pipeline only in development environment.
            /*if (string.Equals(env.EnvironmentName, "Development", StringComparison.OrdinalIgnoreCase))
            {
                app.UseBrowserLink();
                app.UseErrorPage(ErrorPageOptions.ShowAll);
                app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // send the request to the following path or controller action.
                app.UseErrorHandler("/Home/Error");
            }*/

            // Add static files to the request pipeline.
            //app.UseStaticFiles();

            // Add cookie-based authentication to the request pipeline.
            //app.UseIdentity();

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
