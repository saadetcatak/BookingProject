using Microsoft.AspNetCore.Mvc;

namespace BookingProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
