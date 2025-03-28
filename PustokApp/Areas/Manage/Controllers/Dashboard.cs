using Microsoft.AspNetCore.Mvc;

namespace PustokApp.Areas.Manage.Controllers
{
    public class Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
