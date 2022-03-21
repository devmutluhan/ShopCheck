using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Manager;
using Models.Model;

namespace ShopCheckWebApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerManager customerManager;
        public CustomerController(CustomerManager customerManager)
        {
            this.customerManager = customerManager;
        }
        //customer
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(customerManager.Get());
        }
        //customer/1
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(customerManager.Get(id));
        }
        //customer
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            customerManager.Add(customer);
            return Ok();
        }
        //customer/1
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Customer customer, [FromRoute] int id)
        {
            customerManager.Update(customer, id);
            return Ok();
        }
        //customer/1
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            customerManager.Delete(id);
            return Ok();
        }
    }
}
