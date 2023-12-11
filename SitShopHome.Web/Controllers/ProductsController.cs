using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JsonSendRequests.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SitShopHome.Web.Service;

namespace SitShopHome.Web.Controllers
{
    public class ProductsController : Controller
    {

        private const int _PAGESIZE = 10;
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsJsonSendRequest _request;

        public ProductsController(ILogger<ProductsController> logger, IProductsJsonSendRequest request)
        {
            _logger = logger;
            _request = request;
        }

       public IActionResult MainPage()
       {
            var productDTOList = _request.GetProductsOnPage(1,_PAGESIZE);
            var productList = ConvertService.ConvertProductDTOtoViewModel(productDTOList);
            return View(productList);
       }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}