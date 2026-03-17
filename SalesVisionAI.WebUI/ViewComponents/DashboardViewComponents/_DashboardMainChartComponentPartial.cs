using Microsoft.AspNetCore.Mvc;
using SalesVisionAI.WebUI.Context;

namespace SalesVisionAI.WebUI.ViewComponents.DashboardViewComponents
{
    public class _DashboardMainChartComponentPartial : ViewComponent
    {
        private readonly SalesVisionAIDbContext _context;

        public _DashboardMainChartComponentPartial(SalesVisionAIDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            #region Main_Statistics
            // Veriler birkaç ay öncesine ait olduğu için son sipariş tarihine yakın bir tarih kullanıyoruz
            var today = new DateTime(2024, 6, 15);

            var todaySalesCompleted = _context.Orders
                .Where(o => o.OrderDate >= today && o.OrderDate < today.AddDays(1) && o.OrderStatus == "Tamamlandı")
                .Join(_context.Products,
                      order => order.ProductId,
                      product => product.ProductId,
                      (order, product) => new { order.Quantity, product.UnitPrice })
                .Sum(x => (decimal?)(x.Quantity * x.UnitPrice)) ?? 0;

            ViewBag.TodaySales = Math.Round(todaySalesCompleted, 2);


            var todaySalesShipped = _context.Orders
             .Where(o => o.OrderDate >= today && o.OrderDate < today.AddDays(1) && o.OrderStatus == "Kargoda")
             .Join(_context.Products,
                   order => order.ProductId,
                   product => product.ProductId,
                   (order, product) => new { order.Quantity, product.UnitPrice })
             .Sum(x => (decimal?)(x.Quantity * x.UnitPrice)) ?? 0;

            ViewBag.TodaySalesShipped = Math.Round(todaySalesShipped, 2);


            var todaySalesPreparing = _context.Orders
            .Where(o => o.OrderDate >= today && o.OrderDate < today.AddDays(1) && o.OrderStatus == "Hazırlanıyor")
            .Join(_context.Products,
                  order => order.ProductId,
                  product => product.ProductId,
                  (order, product) => new { order.Quantity, product.UnitPrice })
            .Sum(x => (decimal?)(x.Quantity * x.UnitPrice)) ?? 0;

            ViewBag.TodaySalesPreparing = Math.Round(todaySalesPreparing, 2);

            #endregion

            #region Main_Chart
            var sixMonthsAgo = today.AddMonths(-6);

            var monthlySalesRaw = _context.Orders
                .Where(o => o.OrderDate >= sixMonthsAgo)
                .GroupBy(o => new
                {
                    o.OrderDate.Year,
                    o.OrderDate.Month,
                    o.OrderStatus
                })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Durum = g.Key.OrderStatus,
                    SatisAdedi = g.Count()
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToList(); // ⬅ verileri burada çekiyoruz

            // ⬇ Formatlama işlemi artık C# tarafında
            var monthlySales = monthlySalesRaw.Select(x => new
            {
                Ay = $"{x.Year}-{x.Month:D2}",
                x.Durum,
                x.SatisAdedi
            }).ToList();

            // ViewBag'e JSON olarak taşı
            ViewBag.MonthlySalesJson = System.Text.Json.JsonSerializer.Serialize(monthlySales);



            #endregion

            return View();
        }
    }
}
