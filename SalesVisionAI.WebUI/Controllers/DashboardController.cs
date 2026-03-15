using Microsoft.AspNetCore.Mvc;

namespace SalesVisionAI.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
