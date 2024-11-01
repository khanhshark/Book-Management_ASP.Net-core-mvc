using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookASP.DataAccess.data;
using BookASP.DataAccess.Repository.IRepository;
using BookASP.Model;
using Microsoft.AspNetCore.Authorization;
using BookASP.Utility;

namespace BookASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public CategoryController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;

        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitofwork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create() { return View(); }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {

                _unitofwork.Category.Add(obj);
                _unitofwork.save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");

            }

            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category? category = _unitofwork.Category.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "khanh");
            }
            if (ModelState.IsValid)
            {
                _unitofwork.Category.update(obj);
                _unitofwork.save();
                TempData["success"] = "Category update successfully";
                return RedirectToAction("Index");

            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category? category = _unitofwork.Category.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _unitofwork.Category.Get(u => u.Id == id);
            if (ModelState.IsValid && category != null)
            {

                _unitofwork.Category.Remove(category);
                _unitofwork.save();
                TempData["success"] = "Category delete successfully";
                return RedirectToAction("Index");

            }

            return View();
        }
    }
}
