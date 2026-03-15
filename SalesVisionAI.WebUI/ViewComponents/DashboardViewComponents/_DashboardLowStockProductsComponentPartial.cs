using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesVisionAI.WebUI.Context;

namespace SalesVisionAI.WebUI.ViewComponents.DashboardViewComponents
{
    public class _DashboardLowStockProductsComponentPartial : ViewComponent
    {
        private readonly SalesVisionAIDbContext _context;

        public _DashboardLowStockProductsComponentPartial(SalesVisionAIDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Products.Include(x => x.Category).Where(y => y.StockQuantity <= 9).Take(15).ToList();
            return View(values);
        }
    }
}
