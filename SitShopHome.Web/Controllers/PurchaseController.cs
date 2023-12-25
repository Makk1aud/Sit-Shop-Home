using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JsonSendRequests.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.DataTransferObjects;
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
        private readonly IPurchaseJsonSendRequest _purchaseRequest;

        public PurchaseController(ILogger<PurchaseController> logger, IProductsJsonSendRequest productRequest, IPurchaseJsonSendRequest purchaseRequest)
        {
            _logger = logger;
            _productRequest = productRequest;
            _purchaseRequest = purchaseRequest;
        }

        public IActionResult BuyingPage()
        {
            if(GlobalData.ListProductsForPurchases.Count==0)
            {
                return RedirectToAction("CartPage");
            }
            return View();
        }

        [HttpPost]
        public IActionResult BuyingPage(string card)
        {
            
            foreach(var productId in GlobalData.ListProductsForPurchases)
            {
                var purchase = new PurchaseForCreationDTO()
                {
                    ProductId = productId,
                    PurchaseDate = DateTime.Now,
                    PurchaseCard = card
                };

                Guid customerId = (GlobalData.Application["Customer"] as CustomerDTO)!.CustomerId;
                string token = GlobalData.Application["Token"].ToString()!;
                var status = _purchaseRequest.CreatePurchase(purchase, customerId, token);
                if(status != System.Net.HttpStatusCode.Created)
                {
                    ViewBag.Wrong = "Something went wrong";
                    return View();
                }
            }
            GlobalData.ListProductsForPurchases.Clear();
            return RedirectToAction("MainPage", "Products");
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

        public IActionResult SeePurchases()
        {
            Guid customerId = (GlobalData.Application["Customer"] as CustomerDTO)!.CustomerId;
            string token = GlobalData.Application["Token"].ToString()!;

            var purchases = _purchaseRequest.GetAllCustomersPurchases(customerId, token);
            var productList = new List<PurchasesViewModel>();
            foreach(var purchase in purchases)
            {
                var product = _productRequest.GetObject(purchase.ProductId);
                var cartProduct = ConvertService.ConvertOneProductDTOtoViewModel(product);
                var tempPurchase = new PurchasesViewModel()
                {
                    Product = cartProduct,
                    DateBuying = purchase.PurchaseDate 
                };
                productList.Add(tempPurchase);
            }
            return View(productList);
        }
        [HttpPost]
        public IActionResult RemoveProductFromCart(Guid productId)
        {
            GlobalData.ListProductsForPurchases.Remove(productId);
            return RedirectToAction("CartPage");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}