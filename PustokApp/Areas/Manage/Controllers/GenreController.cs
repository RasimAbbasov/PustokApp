using Microsoft.AspNetCore.Mvc;
using PustokApp.Areas.Manage.ViewModel;
using PustokApp.Data;
using PustokApp.Models;

namespace PustokApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class GenreController(PustokDbContext pustokDbContext) : Controller
    {
        public IActionResult Index(int page = 1, int take = 2)
        {
            var query = pustokDbContext.Genres.AsQueryable();
            PaginationVm<Genre> paginatedList = PaginationVm<Genre>.Paginate(query, page, take);
            return View(paginatedList);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var genre = pustokDbContext.Genres.FirstOrDefault(x => x.Id == id);
            if (genre == null)
                return NotFound();
            pustokDbContext.Genres.Remove(genre);
            pustokDbContext.SaveChanges();
            return Ok();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (pustokDbContext.Genres.Any(g => g.Name.ToUpper() == genre.Name.ToUpper()))
            {
                ModelState.AddModelError("Name", "Bu adli janr movcuddur.");
                return View();
            }

            pustokDbContext.Genres.Add(genre);
            pustokDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var genre = pustokDbContext.Genres.FirstOrDefault(x => x.Id == id);
            if (genre == null)
                return NotFound();

            return View(genre);
        }
        [HttpPost]
        public IActionResult Edit(Genre genre)
        {
            if (!ModelState.IsValid)
                return View();
            var existGenre = pustokDbContext.Genres.FirstOrDefault(x => x.Id == genre.Id);
            if (existGenre == null)
                return NotFound();
            if (existGenre.Name != genre.Name
                &&
                pustokDbContext.Genres.Any(g => g.Name.ToUpper() == genre.Name.ToUpper() && g.Id != existGenre.Id)
                )
            {
                ModelState.AddModelError("Name", "There is a genre named like that");
                return View();
            }
            existGenre.Name = genre.Name;
            pustokDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
                return NotFound();
            var genre = pustokDbContext.Genres.FirstOrDefault(x => x.Id == id);
            if (genre == null)
                return NotFound();

            return View(genre);
        }

    }
}
