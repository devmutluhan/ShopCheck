using Microsoft.AspNetCore.Mvc;

namespace ShopCheckWebApp.Controllers.View
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
