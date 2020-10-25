using Blog.Business.Repositories;
using Blog.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Business
{
    public static class ApplicationDbContextSeed
    { 
        public static void SeedCategory(ICategoryRepository categoryRepository)
        {
            if (categoryRepository.GetAll().Count() == 0)
            {
                var categories = new List<Category>
                {
                    new Category { CategoryName = "Tatil", Description = "Açıklama Alanı" },
                    new Category { CategoryName = "Yemek", Description = "Açıklama Alanı" },
                    new Category { CategoryName = "Teknoloji", Description = "Açıklama Alanı" },
                    new Category { CategoryName = "Seyahat", Description = "Açıklama Alanı" },
                };

                categories.ForEach(category => categoryRepository.Add(category));
                categoryRepository.Save();
            }
        }
    }
}
