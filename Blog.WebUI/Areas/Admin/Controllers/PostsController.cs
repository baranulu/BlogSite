using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Business.Data;
using Blog.Entities.Models;
using Blog.Mapper.Infrastructure;
using Blog.Mapper.ViewModels.PostViewModels;
using Blog.Validations.PostValidation;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostsController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IMappedPost _mappedPost;
        private readonly IMappedCategory _mappedCategory;
        private readonly CreateValidator _createValidator; // post validator
        public PostsController(ApplicationContext context, IMappedPost mappedPost, IMappedCategory mappedCategory, CreateValidator createValidtor)
        {
            this._mappedCategory = mappedCategory;
            this._mappedPost = mappedPost;
            this._createValidator = createValidtor;
            _context = context;
        }


        public IActionResult Index()
        {
            var result = _mappedPost.GetAllMappedPosts();
            return View(model: result);
        }


        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_mappedCategory.GetAllMappedCategories(), "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostCreateVM vm, Guid[] categories)
        {
            var model = _createValidator.Validate(vm);
            if (model.IsValid)
            {

                _mappedPost.AddMappedPost(vm, categories);
                _mappedPost.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }





















        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }



        // GET: Admin/Posts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Content,PublishDate,Id,CreatedComputerName,CreatedDate,CreatedBy,CreatedIp")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(Guid id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
