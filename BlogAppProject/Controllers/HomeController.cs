using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogAppProject.Models;
using BlogAppProject.ViewModels;
using BlogAppProject.Services;
using BlogAppProject.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogAppProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,IBlogEmailSender emailSender,ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            var blogs =  await _context.Blogs
                .Include(b=>b.BlogUser)
                .ToListAsync();

            return View(blogs);
        }

        //Blog post index 
        //BlogPostIndex
        public async Task<IActionResult> BlogPostIndex(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var posts = _context.Posts.Where(p => p.BlogId == id).ToList();
            return View("Index", posts);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        //Recieves information from the contact form 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactMe model)
        {
            model.Message = $"{model.Message}<hr/>Phone:{model.Phone}";
            await _emailSender.SendContactEmailAsync(model.Email, model.Name, model.Subject, model.Message);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
