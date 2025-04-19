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

            //var existBook = pustokDbContext.Books
            //    .Where(x => x.Id == id)
            //    .Select(existBook => new BookModalVm
            //    {
            //        Name = existBook.Name,
            //        Description = existBook.Description,
            //        ProductCode = existBook.ProductCode,
            //        InStock = existBook.InStock,
            //        IsFeatured = existBook.IsFeatured,
            //        IsNew = existBook.IsNew,
            //        Price = existBook.Price,
            //        DiscountPercentage = existBook.DiscountPercentage,
            //        Rate = existBook.Rate,
            //        AuthorName = existBook.Author.Name,
            //        GenreName = existBook.Genre.Name,
            //        BookImages = existBook.BookImages.Select(x => x.ImgName).ToList(),
            //        BookTags = existBook.BookTags.Select(x => x.Tag.Name).ToList()
            //    }).FirstOrDefault();
            if (existBook == null)
                return NotFound();

            //BookModalVm bookModalVm = new()
            //{
            //    Name= existBook.Name,
            //    Description= existBook.Description,
            //    ProductCode=existBook.ProductCode,
            //    InStock=existBook.InStock,
            //    IsFeatured=existBook.IsFeatured,
            //    IsNew=existBook.IsNew,
            //    Price=existBook.Price,
            //    DiscountPercentage=existBook.DiscountPercentage,
            //    Rate=existBook.Rate,
            //    AuthorName=existBook.Author.Name,
            //    GenreName=existBook.Genre.Name,
            //    BookImages=existBook.BookImages.Select(x => x.ImgName).ToList(),
            //    BookTags=existBook.BookTags.Select(x => x.Tag.Name).ToList()

            //};

            //return Json(bookModalVm);

            return PartialView("_ModalBookPartial", existBook);
        }
    }
}
