using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Temp.DAL;
using Pustok_Temp.Models;
using Pustok_Temp.ViewModels;

namespace Pustok_Temp.Areas.PustokAdmin.Controllers
{
    [Area("PustokAdmin")]
    public class CategoryController : Controller
    {
        AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                categories = _context.categories
                .Include(p=>p.Books)
                .ToList(),
                books=_context.books.ToList()
                
            };
            return View(homeVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category categories)
        {
            _context.categories.Add(categories);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAll()
        {
            foreach (var item in _context.books)
            {
                _context.books.Remove(item);
            }

            foreach (var item in _context.categories)
            {
                _context.categories.Remove(item);
            }
;
            _context.SaveChanges();

            return  RedirectToAction("Index");

        }

        public IActionResult AddBook(int id)
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddBook(Book Book)
        {

            _context.books.Add(Book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAllBooks()
        {
            foreach (var item in _context.books)
            {
                _context.books.Remove(item);
            }
;
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult UploadBook(int id)
        {

            return RedirectToAction("Index");
        }

    }
}
