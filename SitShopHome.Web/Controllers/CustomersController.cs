using JsonSendRequests.Contracts;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;

namespace SitShopHome.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerJsonSendRequest _customerJsonRequest;

        public CustomersController(ILogger<CustomersController> logger, ICustomerJsonSendRequest customerJsonRequest)
        {
            _logger = logger;
            _customerJsonRequest = customerJsonRequest;
        }

        public IActionResult Registration() => View();

        [HttpPost]
        public IActionResult Registration(CustomerForManipulationDTO? customerObj, DateOnly birthday)
        {
            if(!ModelState.IsValid)
                return View(customerObj);
            if(customerObj == null || birthday == null)
                return View(customerObj);
            
            _customerJsonRequest.CreateCustomer(customerObj, birthday);
            return RedirectToAction("Index","Home" );
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}