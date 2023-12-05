using System.Security.Cryptography.X509Certificates;
using JsonSendRequests.Contracts;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using SitShopHome.Web.Models;

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
            if(customerObj == null)
                return View();
            if(birthday == null)
            {
                ViewBag.BirthIsEmpty = "Birth field is required";
                return View(customerObj);
            }
            if(!ModelState.IsValid)
                return View(customerObj);
            
            
            var result = _customerJsonRequest.CreateCustomer(customerObj, birthday);
            if(result != System.Net.HttpStatusCode.OK)
            {
                ViewBag.NotOk = "Something went wrong";
                return View(customerObj);
            }
            return RedirectToAction("LogInSystem");
        }

        public IActionResult LogInSystem()=> View();
        
        [HttpPost]
        public IActionResult LogInSystem(CustomersToEnterViewModel customerObj)
        {
            if(customerObj == null)
                return View();
            if(!ModelState.IsValid)
                return View(customerObj);

            var customer = _customerJsonRequest.FindCustomer(customerObj.LoginEmail, customerObj.Password);

            if(customer == null)
            {
                return View(customerObj);
            } 
            
            return RedirectToAction("Index","Home" );
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}