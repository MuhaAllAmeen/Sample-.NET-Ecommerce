using BookClub2.Data;
using BookClub2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookClub2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;  
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _db.Categories;
            return View(categoryList);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(Category obj)
        {
            if (ModelState.IsValid) {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        
        public IActionResult EditCategory(int ? id)
        {
            if (id != null)
            {
                var editCategory = _db.Categories.Find(id);
                if(editCategory !=null)
                    return View(editCategory);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategoryPOST(int ? id)
        {
            var deleteCategory = _db.Categories.Find(id);

            _db.Categories.Remove(deleteCategory);
            _db.SaveChanges();
            return RedirectToAction("Index");
            

        }


        public IActionResult DeleteCategory(int? id)
        {
            if (id != null)
            {
                var deleteCategory = _db.Categories.Find(id);
                if (deleteCategory != null)
                    return View(deleteCategory);
            }
            return NotFound();
        }
    }
}
