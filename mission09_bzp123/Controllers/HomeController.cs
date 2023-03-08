using Microsoft.AspNetCore.Mvc;
using mission09_bzp123.Models;
using mission09_bzp123.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_bzp123.Controllers
{
    public class HomeController : Controller
    {
        private IBookStoreRepository repo;
        public HomeController(IBookStoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string bookGenre, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == bookGenre || bookGenre == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = 
                    (bookGenre == null 
                        ? repo.Books.Count() 
                        : repo.Books.Where(b => b.Category == bookGenre).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(x);
        }

    }
}
