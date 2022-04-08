using Microsoft.AspNetCore.Mvc;

namespace Alpheratz.Web.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}