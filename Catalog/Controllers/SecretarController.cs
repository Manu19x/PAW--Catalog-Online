using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [Authorize(Roles = "Secretar")]
    public class SecretarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
