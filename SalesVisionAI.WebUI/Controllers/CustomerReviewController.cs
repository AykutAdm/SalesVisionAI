using Microsoft.AspNetCore.Mvc;

namespace SalesVisionAI.WebUI.Controllers
{
    public class CustomerReviewController : Controller
    {
        public IActionResult CustomerReviewWithOpenAI()
        {
            return View();
        }
    }
}
