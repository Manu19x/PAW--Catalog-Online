using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Catalog_online.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Student")]
        public IActionResult Student()
        {
            return RedirectToAction("Index", "Student");
        }

        [Authorize(Roles = "Profesor")]
        public IActionResult Profesor()
        {
            return RedirectToAction("Index", "Profesor");
        }

        [Authorize(Roles = "Secretar")]
        public IActionResult Secretar()
        {
            return RedirectToAction("Index", "Secretar");
        }

        [Authorize(Roles = "Moderator")]
        public IActionResult Moderator()
        {
            return RedirectToAction("Index", "Moderator");
        }
    }
}
