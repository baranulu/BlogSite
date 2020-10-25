namespace Blog.Mapper.Infrastructure
{
    using Blog.Mapper.ViewModels.CategoryViewModels;
    using System;
    using System.Collections.Generic;

    public interface IMappedCategory
    {
        IEnumerable<CategoryIndexVM> GetAllMappedCategories();
        void AddMappedCategory(CategoryCreateVM vm);
        void UpdateMappedCategory(CategoryEditVM vm);
        CategoryEditVM GetMappedCategory(Guid id);
        void DeleteMappedCategory(CategoryDeleteVM vm);
        CategoryDetailVM GetDetailMappedCategory(Guid id);
        CategoryDeleteVM GetDeleteMappedCategory(Guid id);
        int Save();
    }
}