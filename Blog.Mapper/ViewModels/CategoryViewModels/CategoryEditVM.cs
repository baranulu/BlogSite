using System;
namespace Blog.Mapper.ViewModels.CategoryViewModels
{
    public class CategoryEditVM
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
