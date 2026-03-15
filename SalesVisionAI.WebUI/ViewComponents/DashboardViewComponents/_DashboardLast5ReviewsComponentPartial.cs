using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesVisionAI.WebUI.Context;

namespace SalesVisionAI.WebUI.ViewComponents.DashboardViewComponents
{
    public class _DashboardLast5ReviewsComponentPartial : ViewComponent
    {
        private readonly SalesVisionAIDbContext _context;

        public _DashboardLast5ReviewsComponentPartial(SalesVisionAIDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Reviews.OrderByDescending(x => x.ReviewId).Include(y => y.Customer).Include(z => z.Product).Take(5).ToList();
            return View(values);
        }
    }
}
