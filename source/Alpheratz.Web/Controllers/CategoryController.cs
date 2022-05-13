using Alpheratz.DataAccess.Data;
using Alpheratz.ModelLibrary.Models;
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

        //GET
        public IActionResult Create()
        {
            return View();
        }
        
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the name.");
            }

            if (ModelState.IsValid)
            {
                _context.Categories!.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Category created successfully";

                return RedirectToAction("Index");
            }

            return View(obj);
        }
        
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var category = _context.Categories!.Find(id);

            if (category == null)
                return NotFound();

            return View(category);
        }
        
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the name.");
            }

            if (ModelState.IsValid)
            {
                _context.Categories!.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Category updated successfully";

                return RedirectToAction("Index");
            }

            return View(obj);
        }
        
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var category = _context.Categories!.Find(id);

            if (category == null)
                return NotFound();

            return View(category);
        }
        
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var category = _context.Categories!.Find(id);

            if (category == null)
                return NotFound();

            _context.Categories!.Remove(category);
            _context.SaveChanges();
                TempData["success"] = "Category deleted successfully";

            return RedirectToAction("Index");
        }
    }
}