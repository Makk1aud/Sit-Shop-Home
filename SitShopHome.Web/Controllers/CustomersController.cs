using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;

namespace SitShopHome.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
        }

        public IActionResult Registration() => View();

        [HttpPost]
        public IActionResult Registration(CustomerForManipulationDTO customerObj)
        {
            // Create check if cutomer is null then return goback, else send this object to api
            if(!ModelState.IsValid)
                return View(customerObj);
            if(customerObj == null)
                return View(customerObj);

            return RedirectToAction("Index","Home" );
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}