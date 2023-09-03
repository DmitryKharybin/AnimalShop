using Microsoft.AspNetCore.Mvc;

namespace AnimalShop.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ErrorDisplay()
        {
            return View();
        }
    }
}
