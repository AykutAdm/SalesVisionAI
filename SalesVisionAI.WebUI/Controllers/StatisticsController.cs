using Microsoft.AspNetCore.Mvc;

namespace SalesVisionAI.WebUI.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CategoryCount = 44;
            ViewBag.CustomerCount = 33;
            ViewBag.ProductCount = 22;
            ViewBag.OrderCount = 4;
            ViewBag.CustomerCount = 50;
            ViewBag.CustomerCity = "ankara";
            ViewBag.OrderStatusByCompleted = 5;
            ViewBag.OrderStatusByCancelled = 6;
            ViewBag.OctoberOrders = 25;
            ViewBag.Orders2025Count = 44;
            ViewBag.AverageProductPrice = 50;
            ViewBag.AverageProductQuantity = 66;
            return View();
        }
    }
}
