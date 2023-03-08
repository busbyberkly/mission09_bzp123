using Microsoft.AspNetCore.Mvc;
using mission09_bzp123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_bzp123.Components
{
    public class GenresViewComponent : ViewComponent
    {
        private IBookStoreRepository repo { get; set; }

        public GenresViewComponent (IBookStoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["bookGenre"];

            var genres = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(genres);
        }
    }
}
