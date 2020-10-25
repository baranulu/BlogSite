using AutoMapper;
using Blog.Entities.Models;
using Blog.Mapper.ViewModels.CategoryViewModels;
using Blog.Mapper.ViewModels.PostViewModels;

namespace Blog.Root.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            // CreateMap<Kaynak,Hedef>
            // Categories Mapper Configurations

            // 1. Parametrede verdiğiniz Category nesnesini CategoryIndexVM olarak teslim eder.
            CreateMap<Category, CategoryIndexVM>();

            // 1. Parametrede verdiğiniz Category nesnesini CategoryDeleteVM olarak teslim eder.
            CreateMap<Category, CategoryDeleteVM>();

            // 1. Parametrede verdiğiniz Category nesnesini CategoryDetailVM olarak teslim eder.
            CreateMap<Category, CategoryDetailVM>();

            // 1. Parametrede verdiğiniz CategoryCreateVM nesnesini Category olarak teslim eder.
            CreateMap<CategoryCreateVM, Category>();

            // 1. Parametrede verdiğiniz CategoryDeleteVM nesnesini Category olarak teslim eder.
            CreateMap<CategoryDeleteVM, Category>();

            // 1. Parametrede verdiğiniz Category nesnesini CategoryEditVM olarak teslim eder.
            CreateMap<Category, CategoryEditVM>();

            // map işlemini terisen çevirir. aşşağıdaki yorum satırındaki şekliyle yazabilirsiniz veya reverse kullanıp tersine çevirebilirsiniz.
            // CreateMap<CategoryEditVM, Category>();
            CreateMap<Category, CategoryEditVM>().ReverseMap();




            // Post Mapper Configurations
            CreateMap<Post, PostIndexVM>();
            CreateMap<PostCreateVM, Post>();
            CreateMap<PostCreateVM, Post>().ReverseMap();

        }
    }
}
