using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManager.Data;
using BlogManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogManager.Areas.User.Controllers
{
    [Area("User")]
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BlogController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.BlogPosts.ToList());
        }


        //GET  Create Action Method
        public IActionResult Create()
        {
            return View();
        }

        //POST Create Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPost blogPost)
        {
            if(ModelState.IsValid)
            {
                _db.Add(blogPost);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }

        //GET  EDIT Action Method
        public async Task <IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var blogPost = await _db.BlogPosts.FindAsync(id);
            if(blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        //POST EDIT Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogPost blogPost)
        {
            if (id!= blogPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(blogPost);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }


        //GET  Details Action Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var blogPost = await _db.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }
    }
}