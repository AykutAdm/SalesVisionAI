using Microsoft.AspNetCore.Mvc;
using SalesVisionAI.WebUI.Context;

namespace SalesVisionAI.WebUI.ViewComponents.CustomerAnalyticsViewComponents
{
    public class _CustomerAnalyticsStatisticsComponentPartial : ViewComponent
    {
        private readonly SalesVisionAIDbContext _context;

        public _CustomerAnalyticsStatisticsComponentPartial(SalesVisionAIDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var today = new DateTime(2025, 10, 15);

            ViewBag.TopCustomer = _context.Orders.GroupBy(o => new { o.Customer.CustomerName, o.Customer.CustomerSurname })
            .Select(g => new
            {
                FullName = g.Key.CustomerName + " " + g.Key.CustomerSurname,
                TotalOrders = g.Count()
            }).OrderByDescending(x => x.TotalOrders).Select(x => x.FullName).FirstOrDefault();

            ViewBag.TopCity = _context.Orders.GroupBy(o => o.Customer.CustomerCity).Select(g => new
            {
                City = g.Key,
                TotalOrders = g.Count()
            }).OrderByDescending(x => x.TotalOrders).Select(x => x.City).FirstOrDefault();

            ViewBag.Last30DaysOrderCount = _context.Orders.Where(o => o.OrderDate >= today.AddDays(-30)).Select(o => o.CustomerId).Distinct().Count();

            ViewBag.TopPaymentMethod = _context.Orders.GroupBy(o => o.PaymentMethod).Select(g => new
            {
                PaymentMethod = g.Key,
                TotalOrders = g.Count(),
            }).OrderByDescending(x => x.TotalOrders).Select(y => y.PaymentMethod).FirstOrDefault();

            return View();
        }
    }
}
