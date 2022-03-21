using Microsoft.AspNetCore.Mvc;
using Models.Model;
using BusinessLayer.Manager;

namespace ShopCheckWebApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductManager productManager;
        public ProductController(ProductManager productManager)
        {
            this.productManager = productManager;
        }
        //product
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(productManager.Get());
        }
        //product/1
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(productManager.Get(id));
        }
        //product
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            productManager.Add(product);
            return Ok();
        }
        //product/2
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            productManager.Delete(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Product product, [FromRoute] int Id)
        {
            productManager.Update(product, Id);
            return Ok();
        }
    }
}
