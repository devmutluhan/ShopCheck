using Microsoft.AspNetCore.Mvc;

namespace ShopCheckWebApp.Controllers.View
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
