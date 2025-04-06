using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokApp.Data;
using PustokApp.ViewModel;

namespace PustokApp.Controllers
{
    public class BookController(PustokDbContext pustokDbContext) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
             return NotFound();
            var existBook = pustokDbContext.Books
                .Include(x => x.Author)
                .Include(x => x.Genre)
                .Include(x => x.BookImages)
                .Include(x=>x.BookTags)
                .ThenInclude(x=>x.Tag)
                .FirstOrDefault(x => x.Id == id);
            if(existBook == null)
                return NotFound();
            BookDetailVm bookDetailVm = new BookDetailVm()
            {
                Book = existBook,
                RelatedBooks = pustokDbContext.Books
                .Include(x => x.Author)
                .Include(x => x.Genre)
                .Include(x => x.BookImages)
                .Where(b => b.GenreId == existBook.GenreId)
                .ToList()
            };
            return View(bookDetailVm);
        }
        public IActionResult BookModal(int? id)
        {
            if (id == null)
                return NotFound();
            var existBook = pustokDbContext.Books
                .Include(x => x.Author)
                .Include(x => x.Genre)
                .Include(x => x.BookImages)
                .Include(x => x.BookTags)
                .ThenInclude(x => x.Tag)
                .FirstOrDefault(x => x.Id == id);
            if (existBook == null)
                return NotFound();
            return PartialView("_ModalBookPartial",existBook);
        }
    }
}
