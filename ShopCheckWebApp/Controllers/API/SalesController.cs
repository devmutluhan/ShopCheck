using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Manager;
using Models.Model;

namespace ShopCheckWebApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SalesManager salesManager;
        private readonly ProductManager productManager;
        public SalesController(SalesManager salesManager, ProductManager productManager)
        {
            this.salesManager = salesManager;
            this.productManager = productManager;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(salesManager.GetSales());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(salesManager.GetSale(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Sales sales)
        {
            salesManager.Add(sales);
            productManager.DeleteStock(sales.ProductId);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            salesManager.Delete(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(Sales sales, int Id)
        {
            salesManager.Update(sales, Id);
            return Ok();
        }

    }
}
