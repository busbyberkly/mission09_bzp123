using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission09_bzp123.Models
{
    //interface is like a template for a class that insures that it will be used correctly.
    public interface IBookStoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
