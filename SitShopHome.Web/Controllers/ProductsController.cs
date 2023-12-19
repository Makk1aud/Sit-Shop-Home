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

       public IActionResult MainPage(int pageNumber = 1, int? minPrice =null, int? maxPrice =null)
       {
            if(pageNumber <= 0)
                pageNumber = 1;
            var productDTOList = _request.GetProductsOnPage(pageNumber,_PAGESIZE, minPrice, maxPrice);
            var productList = ConvertService.ConvertProductDTOtoViewModel(productDTOList);
            MainPageViewModel model = new();
            model.PageNumber = pageNumber;
            model.Products = productList;
            model.MaxPrice = maxPrice;
            model.MinPrice = minPrice;
            return View(model);
       }
    
        [HttpPost]
       public IActionResult SearchingProducts(MainPageViewModel model)
       {

            return RedirectToAction("MainPage", new {pageNumber = model.PageNumber,
                                                     minPrice = model.MinPrice,
                                                     maxPrice = model.MaxPrice});
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