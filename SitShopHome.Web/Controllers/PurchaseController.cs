using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JsonSendRequests.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SitShopHome.Web.Models;
using SitShopHome.Web.Models.PageViewModel;
using SitShopHome.Web.Service;
using SitShopHome.Web.Services;

namespace SitShopHome.Web.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ILogger<PurchaseController> _logger;
        private readonly IProductsJsonSendRequest _productRequest;

        public PurchaseController(ILogger<PurchaseController> logger, IProductsJsonSendRequest productRequest)
        {
            _logger = logger;
            _productRequest = productRequest;
        }

        public IActionResult CartPage()
        {
            var model = new CartPageViewModel();
            var productList = new List<MainPageProductViewModel>();
            int totalCost = 0;
            foreach(var productId in GlobalData.ListProductsForPurchases)
            {
                var product = _productRequest.GetObject(productId);
                var cartProduct = ConvertService.ConvertOneProductDTOtoViewModel(product);
                productList.Add(cartProduct);
                totalCost += product.ProductPrice;
            }
            model.Products = productList;
            model.TotalCost = totalCost;
            return View(model);
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}