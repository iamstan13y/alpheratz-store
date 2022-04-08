using Alpheratz.Web.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace Alpheratz.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories!.ToList();
            return View(categories);
        }
    }
}