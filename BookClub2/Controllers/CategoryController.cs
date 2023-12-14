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
    }
}
