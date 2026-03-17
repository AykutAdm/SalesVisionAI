using Microsoft.AspNetCore.Mvc;
using SalesVisionAI.WebUI.Context;

namespace SalesVisionAI.WebUI.ViewComponents.CustomerDetailViewComponents
{
    public class _CustomerDetailMainCoverTableComponentPartial : ViewComponent
    {
        private readonly SalesVisionAIDbContext _context;

        public _CustomerDetailMainCoverTableComponentPartial(SalesVisionAIDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Customers.Where(x => x.CustomerId == 8).FirstOrDefault();
            return View(value);
        }
    }
}
