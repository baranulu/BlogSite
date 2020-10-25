using Blog.Business.Data;
using Blog.Business.Repositories;
using Blog.Entities.Models;
using System;

namespace Blog.Business.Services
{
    public class CategoryRepository : CoreRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context) : base(context) { } 
        public override void Add(Category entity)
        { 
            if (entity == null)
            {
                throw new ArgumentNullException(entity.GetType().Name);
            }
            if (Any(model => model.CategoryName == entity.CategoryName))
            {
                throw new Exception($"{entity.CategoryName} kategorisi daha önce eklendi");
            }
            base.Add(entity); 
        }


        public override void Update(Category entity)
        { 
            if (Any(model => model.Id != entity.Id && model.CategoryName == entity.CategoryName))
            {
                throw new Exception($"{entity.CategoryName} kategorisi daha önce eklendi, Farklı bir kategori adı giriniz");
            }

            base.Update(entity);
        }
    }
}

