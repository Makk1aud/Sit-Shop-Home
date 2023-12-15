using System.Security.Cryptography.X509Certificates;
using AutoMapper.Configuration.Annotations;
using JsonSendRequests.Contracts;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using SitShopHome.Web.Models;
using SitShopHome.Web.Services;

namespace SitShopHome.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerJsonSendRequest _customerJsonRequest;
        private readonly IGenderJsonSendRequest _genderRequest;
        public CustomersController(ILogger<CustomersController> logger,
        ICustomerJsonSendRequest customerJsonRequest,
        IGenderJsonSendRequest genderRequest)
        {
            _logger = logger;
            _customerJsonRequest = customerJsonRequest;
            _genderRequest = genderRequest;
        }

        public IActionResult Registration() 
        {
            ViewData["Genders"] = _genderRequest.GetAllObject();
            return View();
        }

        [HttpPost]
        public IActionResult Registration(CustomerForManipulationDTO? customerObj, DateOnly birthday)
        {

            ViewData["Genders"] = _genderRequest.GetAllObject();
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
            if(result != System.Net.HttpStatusCode.Created)
            {
                ViewBag.NotOk = "Something went wrong";
                return View(customerObj);
            }
            return RedirectToAction("LogInSystem");
        }

        public IActionResult LogInSystem()
        {
            return View()  ;
        } 
        
        [HttpPost]
        public IActionResult LogInSystem(CustomersToEnterViewModel customerObj)
        {
            if(customerObj == null)
                return View();
            if(!ModelState.IsValid)
                return View(customerObj);
            CustomerDTO customer;
            try
            {
                customer = _customerJsonRequest.FindCustomer(customerObj.LoginEmail, customerObj.Password, out string token);
                GlobalData.Application["Token"] = token ?? "No token";
            }
            catch (Exception e)
            {
                ViewBag.NotFound = e.Message.ToString();
                return View(customerObj);
            }
            
            GlobalData.Application["Customer"] = customer!;
            return RedirectToAction("MainPage", "Products");
        }

        public IActionResult Profile()
        {
            var customer = GlobalData.Application["Customer"] as CustomerDTO;
            return View(customer);
        }

        
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}