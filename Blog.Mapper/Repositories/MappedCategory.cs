using System;
using System.Collections.Generic;
using Blog.Mapper.Infrastructure;
using Blog.Mapper.ViewModels.CategoryViewModels;
using AutoMapper;
using Blog.Business.Repositories;
using Blog.Entities.Models;

namespace Blog.Mapper.Repositories
{
    public class MappedCategory : IMappedCategory
    {

        public readonly ICategoryRepository _categoryRepository;
        public IMapper _mapper;
        // ⌃I
        public MappedCategory(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._categoryRepository = categoryRepository;
        }





        public void AddMappedCategory(CategoryCreateVM vm)
        {
            // Burdaki eşleme türünde, içerisine aldığı vm nesnesini Category nesnesine atama yaparken category nesnesinin yeni bir örneğini (instance) alıp işlem yapar

            // <Category> şeklinde kullanırsanız otomatik olarak instance alır
            Category category = _mapper.Map<Category>(vm);
            _categoryRepository.Add(category);
        }
         

        public void DeleteMappedCategory(CategoryDeleteVM vm)
        {
            // aşşağıdaki kullanım şeklinde, instance almadan dbset içerisindeki kaydı map işlemi yapar.
            Category category = _mapper.Map(vm, _categoryRepository.GetById(vm.Id));
            _categoryRepository.Delete(category);
        }



        public IEnumerable<CategoryIndexVM> GetAllMappedCategories()
        {
            var categories = _categoryRepository.GetAll();
            var vm = _mapper.Map<List<CategoryIndexVM>>(categories);
            return vm;
        }

        public CategoryDeleteVM GetDeleteMappedCategory(Guid id)
        {
            Category category = _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDeleteVM>(category);
        }

        public CategoryDetailVM GetDetailMappedCategory(Guid id)
        {
            Category category = _categoryRepository.GetById(id);

            // CategoryDetailVM nesnesinden instance alarak map işelemi yapacak.
            return _mapper.Map<CategoryDetailVM>(category);
        }

        public CategoryEditVM GetMappedCategory(Guid id)
        {
            Category category = _categoryRepository.GetById(id); 
            return _mapper.Map<CategoryEditVM>(category);
        }

        public int Save()
        {
            return _categoryRepository.Save();
        }

        public void UpdateMappedCategory(CategoryEditVM vm)
        {
            Category category = _mapper.Map(vm, _categoryRepository.GetById(vm.Id));
            _categoryRepository.Update(category);
        }
    }
}
