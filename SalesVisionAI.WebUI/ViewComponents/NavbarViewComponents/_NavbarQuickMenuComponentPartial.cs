using Microsoft.AspNetCore.Mvc;

namespace SalesVisionAI.WebUI.ViewComponents.NavbarViewComponents
{
    public class _NavbarQuickMenuComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
