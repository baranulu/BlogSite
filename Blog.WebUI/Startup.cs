using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blog.Root;
using FluentValidation.AspNetCore;
using Blog.Validations;
using Blog.WebUI.Areas.Admin.Utility;

namespace Blog.WebUI
{
    public class Startup
    {
        #region Constructor
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {

            // CompositionRoot.InjectRepositories(services, Configuration);
            // CompositionRoot.InjectMappers(services);
            // CompositionRoot.InjectValidations(services);


            services.InjectMappers();
            services.InjectRepositories(Configuration);
            services.InjectValidations();
            services.AddTransient<IFileUpload, FileSystemFileUploader>();

            services.AddControllersWithViews()
                .AddFluentValidation(validation => validation.RegisterValidatorsFromAssemblyContaining<IValidator>());

        }
        #endregion

        #region Configure
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/home/error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            { 
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}");
            });
        }
        #endregion
    }
}

// migrations komutları

// dotnet ef migrations add "Initialize" --project Blog.Business --startup-project Blog.WebUI --output-dir  Migrations

// dotnet ef database update --project Blog.Business --startup-project Blog.WebUI


// dotnet aspnet-codegenerator controller -name PostImagesController -m PostImage -dc ApplicationContext --relativeFolderPath Areas/Admin/Controllers --useDefaultLayout  

// https://docs.docker.com/engine/reference/commandline/container_ls/
// https://hub.docker.com/_/microsoft-mssql-server