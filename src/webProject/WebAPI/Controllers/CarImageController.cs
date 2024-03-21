using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CarImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
