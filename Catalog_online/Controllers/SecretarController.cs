using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog_online.Controllers
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
