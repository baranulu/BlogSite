using Blog.Business.Data;
using Blog.Business.Repositories;
using Blog.Business.Services;
using Blog.Mapper.Infrastructure;
using Blog.Mapper.Repositories;
using Blog.Root.Helpers; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Root
{
    public static class CompositionRoot
    {
        public static void InjectRepositories(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddDbContext<ApplicationContext>(
              options => options.UseSqlServer(configuration.GetConnectionString("local"))
          );


            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPostImageRepository, PostImageRepository>();
        }

        public static void InjectMappers(this IServiceCollection services)
        {
            var configuration = new AutoMapper.MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapperProfile());
            });
            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped(typeof(IMappedCategory), typeof(MappedCategory));
            services.AddScoped(typeof(IMappedPost), typeof(MappedPost));
        }

        public static void InjectValidations(this IServiceCollection services)
        {

            // kategori validations
            services.AddTransient<Blog.Validations.CategoryValidation.CreateValidator>(); 
            services.AddTransient<Blog.Validations.CategoryValidation.EditValidator>();

            // post validation
            services.AddTransient<Blog.Validations.PostValidation.CreateValidator>();
        }
    }
}
