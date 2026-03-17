using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesVisionAI.WebUI.Context;
using SalesVisionAI.WebUI.Models;

namespace SalesVisionAI.WebUI.ViewComponents.DashboardViewComponents
{
    public class _DashboardTodayOrdersComponentPartial : ViewComponent
    {
        private readonly SalesVisionAIDbContext _context;

        public _DashboardTodayOrdersComponentPartial(SalesVisionAIDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // Veriler birkaç ay öncesine ait olduğu için son sipariş tarihine yakın bir tarih kullanıyoruz
            var today = new DateTime(2024, 6, 15);
            var tomorrow = today.AddDays(1);

            var last10Orders = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Product)
                .Where(o => o.OrderDate >= today && o.OrderDate < tomorrow)
                .OrderByDescending(o => o.OrderDate)
                .Take(5)
                .Select(o => new OrderSummaryViewModel
                {
                    OrderId = o.OrderId,
                    ProductName = o.Product.ProductName,
                    CustomerName = o.Customer.CustomerName + " " + o.Customer.CustomerSurname,
                    Quantity = o.Quantity,
                    PaymentMethod = o.PaymentMethod,
                    OrderStatus = o.OrderStatus,
                    UnitPrice = o.Product.UnitPrice
                })
                .ToList();
            return View(last10Orders);
        }
    }
}
