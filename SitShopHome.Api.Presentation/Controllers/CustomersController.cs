using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
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

        [HttpGet("{customerId}", Name ="GetCustomerById")]
        public IActionResult GetCustomer(Guid customerId)
        {
            var customer = _serviceManager.Customer.GetCustomer(customerId, trackChanges: false);
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerForManipulationDTO customerForManipulation, DateOnly? birth)
        {
            if (customerForManipulation is null || birth is null)
                return BadRequest("Sent object cant be null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = _serviceManager.Customer.CreateCustomer(customerForManipulation, (DateOnly)birth);

            return CreatedAtRoute("GetCustomerById", new { customerId = customer.CustomerId }, customer);
        }
    }
}
