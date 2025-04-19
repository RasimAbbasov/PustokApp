using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokApp.Data;
using PustokApp.Models;
using PustokApp.Services;
using PustokApp.ViewModel;
using System.Diagnostics;

namespace PustokApp.Controllers
{
    public class HomeController(PustokDbContext pustokDbContext,LayoutService layoutService) : Controller
    {
        public IActionResult Index()
        {
            HomeVm homeVm = new HomeVm
            {
                Sliders = pustokDbContext.Sliders.ToList(),
                Features = pustokDbContext.Features.ToList(),
                FeaturedBooks = pustokDbContext.Books
                .Where(x => x.IsFeatured)
                .Include(x=>x.Author)
                .Include(x=>x.BookImages.Where(b=>b.Status!=null))
                .ToList(),
                NewBooks=pustokDbContext.Books.Where(x=>x.IsNew)
                .Include(x => x.Author)
                .Include(x => x.BookImages.Where(b => b.Status != null))
                .ToList(),
                DiscountBooks=pustokDbContext.Books
                .Where(x=>x.DiscountPercentage>0)
                .Include(x => x.Author)
                .Include(x => x.BookImages.Where(b => b.Status != null))
                .ToList()
            };
            return View(homeVm);
        }
    }
}
