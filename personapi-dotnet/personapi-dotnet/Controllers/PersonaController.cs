using Microsoft.AspNetCore.Mvc;

namespace personapi_dotnet.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
