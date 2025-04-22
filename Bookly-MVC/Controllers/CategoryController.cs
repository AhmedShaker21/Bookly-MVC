using Bookly_MVC.Data;
using Bookly_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookly_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext DB)
        {
            _db = DB; 
        }

        public IActionResult Index()
        {
            List<Category> CategoryObjectList = _db.Categories.ToList();
            return View(CategoryObjectList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
                ModelState.AddModelError("Name", "The Display Order Cann't Exactly Match The Name...");
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index"); 
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id ==0)
                return NotFound();
            Category CategoryFromDb = _db.Categories.Find(id)!;
            if (CategoryFromDb is null)
                return NotFound();
            return View(CategoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully";

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if(id == null || id ==0)
                return NotFound();
            Category CategoryFromDb = _db.Categories.Find(id)!;
            if (CategoryFromDb is null)
                return NotFound();
            return View(CategoryFromDb);
        }

        [HttpPost , ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category category = _db.Categories.Find(id)!;
            if (category is null)
                return NotFound();
            _db.Categories.Remove(category);
            TempData["success"] = "Category Deleted Successfully";

            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
