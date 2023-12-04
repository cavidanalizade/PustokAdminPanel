using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Pustok_Temp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Pustok_Temp.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CartController : Controller
    {
        private const string CartCookieKey = "Cart";
        AppDbContext _db;

        public CartController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<BookCartItem> cartItems = GetCartItemsFromCookie();
            foreach (var item in cartItems)
            {
                if(item.BookId==_db.books.Where(b=>b.Id==item.BookId).FirstOrDefault())
            }
            
            return View(cartItems);
        }

        public IActionResult AddToCart(int bookId)
        {
            List<BookCartItem> cartItems = GetCartItemsFromCookie();

            BookCartItem existingItem = cartItems.FirstOrDefault(item => item.BookId == bookId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                BookCartItem newItem = new BookCartItem
                {
                    BookId = bookId,
                    Quantity = 1
                };

                cartItems.Add(newItem);
            }

            UpdateCartItemsInCookie(cartItems);

            return RedirectToAction("Index");
        }


        #region Functions
        private List<BookCartItem> GetCartItemsFromCookie()
        {
            string cartJson = Request.Cookies[CartCookieKey];

            if (string.IsNullOrEmpty(cartJson))
            {
                return new List<BookCartItem>();
            }

            return JsonConvert.DeserializeObject<List<BookCartItem>>(cartJson);
        }

        private void UpdateCartItemsInCookie(List<BookCartItem> cartItems)
        {
            string cartJson = JsonConvert.SerializeObject(cartItems);

            Response.Cookies.Append(CartCookieKey, cartJson);
        }
        #endregion



    }



}

