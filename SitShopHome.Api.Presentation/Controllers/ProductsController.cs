﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetProducts()
        {
            var products = _serviceManager.Product.GetProducts(trackChanges: false);
            return Ok(products);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateProduct([FromBody] ProductForManipulationDTO productForManipulation)
        {
            var product = _serviceManager.Product.CreateProduct(productForManipulation);
            return CreatedAtRoute("ProductById", new { productId = product.ProductId }, product);
        }

        [HttpPut("{productId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult UpdateProduct([FromBody] ProductForManipulationDTO productForManipulation, Guid productId)
        {
            var product = _serviceManager.Product.UpdateProduct(productId, productForManipulation, trackChanges: true);
            return Ok(product);
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(Guid productId)
        {
            _serviceManager.Product.DeleteProduct(productId, trackChanges:false);
            return NoContent();
        }
    }
}
