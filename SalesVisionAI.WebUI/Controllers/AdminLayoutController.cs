using Microsoft.AspNetCore.Mvc;

namespace SalesVisionAI.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
