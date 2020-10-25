using System;
using Microsoft.AspNetCore.Mvc;
using Blog.Entities.Models;
using Blog.Business.Repositories;
using System.Collections.Generic;

namespace Blog.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;

        }


        public IEnumerable<Category> Get()
        {
            return _categoryRepository.GetAll();

        }
    }
}
