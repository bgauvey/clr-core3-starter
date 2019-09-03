using clr_core3_starter.Repository;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace clr_core3_starter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add SqLite support
            services.AddDbContext<MesDbContext>(options => {
                options.UseSqlite(Configuration.GetConnectionString("MesSqliteConnectionString"));
            });

            services.AddControllersWithViews();

            services.AddScoped<IItemsRepository,ItemsRepository>();
            services.AddTransient<MesDbSeeder>();

            // Handle XSRF Name for Header
            services.AddAntiforgery(options => {
                options.HeaderName = "X-XSRF-TOKEN";
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "Client/dist";
            });

            services.AddCors(o => o.AddPolicy("AllowAllPolicy", options =>
            {
                options.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            }));

            services.AddCors(o => o.AddPolicy("AllowSpecific", options =>
                    options.WithOrigins("http://localhost:4200")
                           .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE")
                           .WithHeaders("accept", "content-type", "origin", "X-Inline-Count")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
             MesDbSeeder mesDbSeeder, IAntiforgery antiforgery)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Manually handle setting XSRF cookie. Needed because HttpOnly 
            // has to be set to false so that
            // Angular is able to read/access the cookie.
            app.Use((context, next) =>
            {
                string path = context.Request.Path.Value;
                if (path != null && !path.ToLower().Contains("/api"))
                {
                    var tokens = antiforgery.GetAndStoreTokens(context);
                    context.Response.Cookies.Append("XSRF-TOKEN",
                        tokens.RequestToken,
                        new CookieOptions
                        {
                            HttpOnly = false
                        }
                    );
                }

                return next();
            });

            // This would need to be locked down as needed (very open right now)
            app.UseCors("AllowAllPolicy");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "Client";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            mesDbSeeder.SeedAsync(app.ApplicationServices).Wait();
        }
    }
}
