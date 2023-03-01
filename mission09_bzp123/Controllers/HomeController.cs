using Microsoft.AspNetCore.Mvc;
using mission09_bzp123.Models;
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

        public IActionResult Index()
        {
            var booklist = repo.Books.ToList();
            return View(booklist);
        }

    }
}
