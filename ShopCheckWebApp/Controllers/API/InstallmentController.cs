using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Manager;
using Models.Model;

namespace ShopCheckWebApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentController : ControllerBase
    {
        private readonly InstallmentManager ınstallmentManager;
        public InstallmentController(InstallmentManager ınstallmentManager)
        {
            this.ınstallmentManager = ınstallmentManager;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ınstallmentManager.Get());
        }
    }
}

