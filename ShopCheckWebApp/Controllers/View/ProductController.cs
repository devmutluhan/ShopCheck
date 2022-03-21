using Microsoft.AspNetCore.Mvc;

namespace ShopCheckWebApp.Controllers.View
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
