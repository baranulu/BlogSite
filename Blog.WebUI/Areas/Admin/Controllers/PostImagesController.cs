using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Business.Data;
using Blog.Entities.Models;
using Blog.WebUI.Areas.Admin.Utility;
using Blog.Business.Repositories;
using Microsoft.AspNetCore.Http;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostImagesController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IFileUpload _fileUpload;
        private readonly IPostImageRepository _postImageRepository;
        private readonly IPostRepository _postRepository;


        public PostImagesController(IFileUpload fileUpload, ApplicationContext _context, IPostImageRepository postImageRepository, IPostRepository postRepository,ApplicationContext context)
        {
            _context = context;
            this._fileUpload = fileUpload;
            this._postImageRepository = postImageRepository;

            this._postRepository = postRepository;
        }

        // GET: Admin/PostImages
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.PostImages.Include(p => p.Post);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Admin/PostImages/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postImage = await _context.PostImages
                .Include(p => p.Post)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postImage == null)
            {
                return NotFound();
            }

            return View(postImage);
        }

        // GET: Admin/PostImages/Create
        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Content");
            return View();
        }

        // POST: Admin/PostImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageURL,Base64,Active,PostId,Id,CreatedComputerName,CreatedDate,CreatedBy,CreatedIp")] PostImage postImage)
        {
            if (ModelState.IsValid)
            {
                postImage.Id = Guid.NewGuid();
                _context.Add(postImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Content", postImage.PostId);
            return View(postImage);
        }

        // GET: Admin/PostImages/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postImage = await _context.PostImages.FindAsync(id);
            if (postImage == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Content", postImage.PostId);
            return View(postImage);
        }

        // POST: Admin/PostImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ImageURL,Base64,Active,PostId,Id,CreatedComputerName,CreatedDate,CreatedBy,CreatedIp")] PostImage postImage)
        {
            if (id != postImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostImageExists(postImage.Id))
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
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Content", postImage.PostId);
            return View(postImage);
        }

        // GET: Admin/PostImages/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postImage = await _context.PostImages
                .Include(p => p.Post)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postImage == null)
            {
                return NotFound();
            }

            return View(postImage);
        }

        // POST: Admin/PostImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var postImage = await _context.PostImages.FindAsync(id);
            _context.PostImages.Remove(postImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostImageExists(Guid id)
        {
            return _context.PostImages.Any(e => e.Id == id);
        }


        public IActionResult Upload(Guid id)
        {
            return View(id);
        }
        [HttpPost]
        public IActionResult Upload(IFormFile[] file, Guid? id) //bilinçli olarak file býrakýldý. dropzone içerinde tanýmlý kelime file!!!!
        {
            if (!id.HasValue)
            {
                Post post = _postRepository.GetById(id.Value);
                if (id == null)
                {
                    return NotFound();
                }

                if (file.Length > 0)
                {
                    foreach (var item in file)
                    {
                        var result = _fileUpload.Upload(item);
                        if (result.FileResult == Utility.FileResult.Succeded)
                        {
                            PostImage image = new PostImage();
                            image.ImageURL = result.FileUrl;
                            image.PostId = id.Value;
                        }
                    }
                }


            }


            return View();
        }



    }




}
    