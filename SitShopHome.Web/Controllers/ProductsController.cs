using JsonSendRequests.Contracts;
using Microsoft.AspNetCore.Mvc;
using SitShopHome.Web.Models;
using SitShopHome.Web.Service;
using SitShopHome.Web.Services;

namespace SitShopHome.Web.Controllers
{
    public class ProductsController : Controller
    {

        private const int _PAGESIZE = 10;
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsJsonSendRequest _request;
        private readonly IProductCategoryJsonSendRequest _productCategoryRequest;

        public ProductsController(ILogger<ProductsController> logger, IProductsJsonSendRequest request, IProductCategoryJsonSendRequest preqeust)
        {
            _logger = logger;
            _request = request;
            _productCategoryRequest = preqeust;
        }

       public IActionResult MainPage()
       {
            var productDTOList = _request.GetProductsOnPage(1,_PAGESIZE);
            var productList = ConvertService.ConvertProductDTOtoViewModel(productDTOList);
            return View(productList);
       }
        [HttpPost]
       public IActionResult ProductsPage(string id)
       {
            string token = GlobalData.Application["Token"].ToString()!;
            var productDTO = _request.GetObject(Guid.Parse(id), token);
            //Adding ProductViewModel for this page;
            return View(productDTO);
       }

       public IActionResult CreateProduct()
       {
            
            ViewData["ProductCategories"] = _productCategoryRequest.GetAllObject();
            return View();
       }

       [HttpPost]
       public IActionResult CreateProduct(ProductViewModel model)
       {
            return RedirectToAction("MainPage");
       }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}