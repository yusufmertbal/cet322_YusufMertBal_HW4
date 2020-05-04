using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using YusufMertBookStore.Data;
using YusufMertBookStore.Models;
using YusufMertBookStore.ViewModel;

namespace YusufMertBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Search() 
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel searchModel)
        {
            
            var books = _context.Books.AsQueryable();

            if (searchModel.SerachInDescription)
            {
                books = books.Where(b => b.Title.Contains(searchModel.SearchText) || b.Description.Contains(searchModel.SearchText));
            }
            else
            {
                books = books.Where(b => b.Title.Contains(searchModel.SearchText));
            }

            if (searchModel.CategoryId.HasValue) 
            {
                books = books.Where(b => b.CategoryId == searchModel.CategoryId.Value);
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name",searchModel.CategoryId);
            searchModel.Results = await books.ToListAsync();
            return View(searchModel);
        }
    }
}
