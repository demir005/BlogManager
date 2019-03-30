using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManager.Data;
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
    }
}