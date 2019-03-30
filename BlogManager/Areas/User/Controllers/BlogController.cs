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
    }
}