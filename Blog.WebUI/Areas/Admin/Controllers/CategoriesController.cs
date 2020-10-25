using System;
using System.Linq;
using System.Threading.Tasks;
using Blog.Business.Data;
using Blog.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Business.Repositories;
using Blog.Mapper.Infrastructure;
using Blog.Mapper.ViewModels.CategoryViewModels;
using Blog.Validations.CategoryValidation;
namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        #region Constructor 
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMappedCategory _mappedCategory;
        private readonly CreateValidator _createValidator;
        private readonly EditValidator _editValidator;


        public CategoriesController(
            ICategoryRepository categoryRepository,
            IMappedCategory mappedCategory,
            CreateValidator createValidator,
            EditValidator editValidator
            )
        {
            this._mappedCategory = mappedCategory;
            this._categoryRepository = categoryRepository;
            this._createValidator = createValidator;
            this._editValidator = editValidator;
        }
        #endregion

        #region Index

        public IActionResult Index()
        {


            // 1. Yöntem
            /*
            var categoriesVMs = new List<CategoryIndexVM>(); 
            foreach (var item in categories)
            {
                categoriesVMs.Add(new CategoryIndexVM
                {
                    Id = item.Id,
                    CategoryName = item.CategoryName,
                    Description = item.Description
                });
            }
            return View(categoriesVMs);
            */




            // 2. Yöntem
            /*
            var categories = _categoryRepository.GetAll()
                .Select(x => new CategoryIndexVM
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName,
                    Description = x.Description
                }) ;



            return View(categories);

    */
            // 3. Yöntem AutoMapper Kullanımı
            var categories = _mappedCategory.GetAllMappedCategories();
            return View(categories);
        }

        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryCreateVM vm)
        {

            var model = _createValidator.Validate(vm);
            if (model.IsValid)
            {
                _mappedCategory.AddMappedCategory(vm);
                _mappedCategory.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        #endregion

        #region Edit
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _mappedCategory.GetMappedCategory(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, CategoryEditVM vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }
            var model = _editValidator.Validate(vm);
            if (model.IsValid)
            {
                try
                {
                    _mappedCategory.UpdateMappedCategory(vm);
                    _mappedCategory.Save();
                }
                catch
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }
        #endregion

        #region Details
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _mappedCategory.GetDetailMappedCategory(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        #endregion Details

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _mappedCategory.GetDeleteMappedCategory(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var category = _mappedCategory.GetDeleteMappedCategory(id);
            _mappedCategory.DeleteMappedCategory(category);
            _mappedCategory.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
