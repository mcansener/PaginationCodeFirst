using Microsoft.AspNetCore.Mvc;
using PaginationCodeFirst.Context;
using PaginationCodeFirst.Models;

namespace PaginationCodeFirst.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var books = _context.Books
                .OrderBy(b => b.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var totalBooks = _context.Books.Count();
            var totalPages = (int)Math.Ceiling((double)totalBooks / pageSize);

            var viewModel = new PaginatedList<Book>(books, page, totalPages);

            return View(viewModel);
        }
    }
}
