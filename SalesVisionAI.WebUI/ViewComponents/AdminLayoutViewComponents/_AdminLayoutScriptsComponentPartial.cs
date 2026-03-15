using Microsoft.AspNetCore.Mvc;

namespace SalesVisionAI.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
