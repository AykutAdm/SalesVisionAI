using Microsoft.AspNetCore.Mvc;

namespace SalesVisionAI.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutPageLoaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
