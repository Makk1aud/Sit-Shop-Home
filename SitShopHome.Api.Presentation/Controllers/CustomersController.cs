using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using SitShopHome.Api.Presentation.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitShopHome.Api.Presentation.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CustomersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _serviceManager.Customer.GetCustomers(trackChanges: false);
            return Ok(customers);
        }

        [HttpGet("{customerId}", Name = "GetCustomerById")]
        public IActionResult GetCustomer(Guid customerId)
        {
            var customer = _serviceManager.Customer.GetCustomer(customerId, trackChanges: false);
            return Ok(customer);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateCustomer([FromBody] CustomerForManipulationDTO customerForManipulation, DateOnly? birth)
        {
            //Проверка на уникальный логин
            if (birth is null)
                return BadRequest("Sent birth cant be null");

            var customer = _serviceManager.Customer.CreateCustomer(customerForManipulation, (DateOnly)birth);

            return CreatedAtRoute("GetCustomerById", new { customerId = customer.CustomerId }, customer);
        }

        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(Guid customerId)
        {
            _serviceManager.Customer.DeleteCustomer(customerId, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{customerId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult UpdateCustomer(Guid customerId, [FromBody] CustomerForManipulationDTO customerForManipulation, DateOnly? birth)
        {
            var UpdatedCustomer = _serviceManager.Customer.UpdateCustomer(customerId, customerForManipulation, trackChanges: true, birth);
            return Ok(UpdatedCustomer);
        }
    }
}
