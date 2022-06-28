using Alpheratz.DataAccess.Repository.IRepository;
using Alpheratz.ModelLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alpheratz.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IActionResult Index()
        {
            IEnumerable<CoverType> categories = _unitOfWork.CoverType.GetAll();
            return View(categories);
        }

        //GET
        public IActionResult Upsert(int? id)
        {
            Product product = new();
            if (id == null || id == 0) 
            {
                return View(product);
            }
            else
            {

            }

            return View(product);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();

                TempData["success"] = "Cover Type updated successfully";

                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var coverType = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (coverType == null)
                return NotFound();

            return View(coverType);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var coverType = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (coverType == null)
                return NotFound();

            _unitOfWork.CoverType.Remove(coverType);
            _unitOfWork.Save();
            TempData["success"] = "Cover Type deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
