using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using SitShopHome.Api.Presentation.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SitShopHome.Api.Presentation.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProductsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{productId}", Name ="ProductById")]
        public IActionResult GetProduct(Guid productId)
        {
            var product = _serviceManager.Product.GetProduct(productId, trackChanges: false);
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetProducts([FromQuery] ProductsParameters productsParameters)
        {
            var products = _serviceManager.Product.GetProducts(productsParameters, trackChanges: false);

            Response.Headers.Add("Info-Pagination", JsonSerializer.Serialize(products.metaData));
            return Ok(products.products);
        }

        [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateProduct([FromBody] ProductForManipulationDTO productForManipulation)
        {
            var product = _serviceManager.Product.CreateProduct(productForManipulation);
            return CreatedAtRoute("ProductById", new { productId = product.ProductId }, product);
        }

        [Authorize]
        [HttpPut("{productId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult UpdateProduct([FromBody] ProductForManipulationDTO productForManipulation, Guid productId)
        {
            var product = _serviceManager.Product.UpdateProduct(productId, productForManipulation, trackChanges: true);
            return Ok(product);
        }

        [Authorize]
        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(Guid productId)
        {
            _serviceManager.Product.DeleteProduct(productId, trackChanges:false);
            return NoContent();
        }
    }
}
