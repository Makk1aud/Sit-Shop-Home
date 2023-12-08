using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using SitShopHome.Api.Presentation.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitShopHome.Api.Presentation.Controllers
{
    [ApiController]
    [Route("api/productscategories")]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProductCategoriesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetProductCategories()
        {
            var categories = _serviceManager.ProductCategory.GetProductsCategories(trackChanges: false);
            return Ok(categories);
        }

        [HttpGet("{categoryId}", Name ="ProductCategoryById")]
        public IActionResult GetProductCategory(Guid categoryId)
        {
            var category = _serviceManager.ProductCategory.GetProductCategory(categoryId, trackChanges : false);   
            return Ok(category);
        }

        [Authorize]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateProductCategory([FromBody] ProductCategoryForManipulationDTO categoryForManipulation)
        {
            var category = _serviceManager.ProductCategory.CreateProductCategory(categoryForManipulation);
            return CreatedAtRoute("ProductCategoryById", new { categoryId = category.id }, category);
        }

        [Authorize]
        [HttpPut("{categoryId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult UpdateProductCategory(Guid categoryId, [FromBody] ProductCategoryForManipulationDTO categoryForManipulation)
        {
            var category = _serviceManager.ProductCategory.UpdateProductCategory(categoryId, categoryForManipulation, trackChanges: true);
            return Ok(category);
        }

        [Authorize]
        [HttpDelete("{categoryId}")]
        public IActionResult DeleteProductCategory(Guid categoryId)
        {
            _serviceManager.ProductCategory.DeleteProductCategory(categoryId, trackChanges: false);
            return NoContent();
        }
    }
}
