using Microsoft.AspNetCore.Mvc;
using PustokApp.Areas.Manage.ViewModel;
using PustokApp.Data;
using PustokApp.Models;

namespace PustokApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController(PustokDbContext pustokDbContext) : Controller
    {
        public IActionResult Index(int page = 1, int take = 2)
        {
            var query = pustokDbContext.Sliders.AsQueryable();
            var paginatedList = PaginationVm<Slider>.Paginate(query, page, take);

            return View(paginatedList);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var slider = pustokDbContext.Sliders.FirstOrDefault(x => x.Id == id);
            if (slider == null)
                return NotFound();
            pustokDbContext.Sliders.Remove(slider);
            pustokDbContext.SaveChanges();
            return Ok();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            pustokDbContext.Sliders.Add(slider);
            pustokDbContext.SaveChanges();
            return View();  
        }
    }
}
