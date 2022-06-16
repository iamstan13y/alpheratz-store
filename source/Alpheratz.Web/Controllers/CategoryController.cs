using Alpheratz.DataAccess.Data;
using Alpheratz.DataAccess.Repository.IRepository;
using Alpheratz.ModelLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alpheratz.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _categoryRepository.GetAll();
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
                _categoryRepository.Add(obj);
                _categoryRepository.Save();

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

            var category = _categoryRepository.GetFirstOrDefault(u => u.Id == id);

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
                _categoryRepository.Update(obj);
                _categoryRepository.Save();

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