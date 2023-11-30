using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok_Temp.Areas.PustokAdmin.ViewModels;
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

           await _context.categories.AddAsync(categories);
           await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.categories.Find(id);
            foreach (var item in _context.books)
            {
                if (item.CategoryId == id)
                {
                    _context.Remove(item);
                }
            }
            _context.categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult UpdateCategory(int id)
        {
            Category category = _context.categories.Find(id);
            UpdateCategoryVM updateCategoryVM = new UpdateCategoryVM
            {
                Id = id,
                Name=category.Name
            };
            return View(updateCategoryVM);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category newCategory)
        {
            Category oldCategory = _context.categories.Find(newCategory.Id);
            oldCategory.Id=newCategory.Id;
            oldCategory.Name=newCategory.Name;
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

        public IActionResult AddBook()
        {
            ViewBag.Categories = _context.categories.ToList();
            ViewBag.Authors =  _context.authors.ToList();
            ViewBag.Tags = _context.tags.ToList();


            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddBook(CreateBookVM  createBookVM)
        {

             ViewBag.Categories = await _context.categories.ToListAsync();
            ViewBag.Authors= await _context.authors.ToListAsync();


            Book book = new Book
            {
                Title = createBookVM.Title,
                Price = createBookVM.Price,
                ImgUrl = createBookVM.ImgUrl,
                CategoryId = createBookVM.CategoryId,
                

            };
            _context.books.Add(book);
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

        public async Task<IActionResult> UpdateBook(int id)
        {
            Book book = await _context.books.Where(b => b.Id == id).FirstOrDefaultAsync();
            ViewBag.Categories = await _context.categories.ToListAsync();
            ViewBag.Authors = await _context.authors.ToListAsync();
            UpdateBookVM updateBookVM = new UpdateBookVM
            {
                Id = id,
                Title=book.Title,
                Price=book.Price,
                ImgUrl=book.ImgUrl, 
                CategoryId=book.CategoryId
            };


            return View(updateBookVM);
        }

               [HttpPost]
        public IActionResult UpdateBook(Book newBook)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            Book oldBook = _context.books.Find(newBook.Id);
            oldBook.Id=newBook.Id;
            oldBook.Title = newBook.Title;
            oldBook.Price = newBook.Price;
            oldBook.ImgUrl = newBook.ImgUrl;
            oldBook.CategoryId = newBook.CategoryId;


            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteBook(int id)
        {
            var book = _context.books.Find(id);
            _context.Remove(book);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

    }
}
