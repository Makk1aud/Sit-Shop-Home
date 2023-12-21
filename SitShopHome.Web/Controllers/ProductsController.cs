using JsonSendRequests.Contracts;
using Microsoft.AspNetCore.Mvc;
using SitShopHome.Web.Models;
using SitShopHome.Web.Models.PageViewModel;
using SitShopHome.Web.Service;
using SitShopHome.Web.Services;

namespace SitShopHome.Web.Controllers
{
    public class ProductsController : Controller
    {

        private const int _PAGESIZE = 3;
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsJsonSendRequest _request;
        private readonly IProductCategoryJsonSendRequest _productCategoryRequest;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductsController(ILogger<ProductsController> logger, 
        IProductsJsonSendRequest request,
        IProductCategoryJsonSendRequest preqeust,
        IWebHostEnvironment host)
        {
            _logger = logger;
            _request = request;
            _productCategoryRequest = preqeust;
            _hostingEnvironment = host;
        }

       public IActionResult MainPage(int pageNumber = 1, 
       int? minPrice =null, 
       int? maxPrice =null,
       string? searchName = null,
       Guid? category = null,
       Guid? productId = null)
       {
            if(productId != null)
            {
                if(!GlobalData.ListProductsForPurchases.Contains(Guid.Parse(productId.ToString()!)))
                    GlobalData.ListProductsForPurchases.Add(Guid.Parse(productId.ToString()!));
                else
                    ViewBag.ExistInCart = "This product has already add in cart";
 
            }
           if(pageNumber <= 0)
                pageNumber = 1;
            if(minPrice > maxPrice)
            {
                minPrice = maxPrice;
                maxPrice = minPrice;
            }
            var productDTOList = _request.GetProductsOnPage(pageNumber,_PAGESIZE, minPrice, maxPrice,searchName,category);
            var productList = ConvertService.ConvertProductDTOtoViewModel(productDTOList);
            MainPageViewModel model = new();
            model.PageNumber = pageNumber;
            model.Products = productList;
            model.MaxPrice = maxPrice;
            model.MinPrice = minPrice;
            model.SearchName = searchName;
            model.ProductCategoryId = category;
            ViewData["Category"] = _productCategoryRequest.GetAllObject();
            return View(model);
       }

       public IActionResult AddProductToCart(Guid productId)
       {
        System.Console.WriteLine(productId.ToString());
        return Ok();
       }

        [HttpPost]
       public IActionResult SearchingProducts(MainPageViewModel model)
       {

            return RedirectToAction("MainPage", new {pageNumber = model.PageNumber,
                                                     minPrice = model.MinPrice,
                                                     maxPrice = model.MaxPrice,
                                                     searchName = model.SearchName,
                                                     category = model.ProductCategoryId});
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
            ViewData["ProductCategories"] = _productCategoryRequest.GetAllObject();
            if(!ModelState.IsValid)
                return View(model);
            
            string filePathForDb = "Source\\Images\\"+ Guid.NewGuid().ToString() + model.File.FileName;
            string filePath = Path.Combine(_hostingEnvironment.WebRootPath,filePathForDb );
            using(Stream fileStream = new FileStream(filePath,FileMode.Create))
                model.File.CopyTo(fileStream);
            System.Console.WriteLine(filePathForDb.Length);
            var product = ConvertService.ConvertProductViewModelToDTO(model, filePathForDb);
            string token = GlobalData.Application["Token"].ToString()!;
            var status = _request.CreateProduct(product, token);
            if(status != System.Net.HttpStatusCode.Created)
            {
                ViewBag.SomethingWrong = "Something went wrong";
                return View(model);
            }
            return RedirectToAction("MainPage");
       }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}