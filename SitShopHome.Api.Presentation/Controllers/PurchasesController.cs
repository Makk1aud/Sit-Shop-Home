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
    [Authorize]
    [ApiController]
    [Route("api/customers/{customerId}/purchases")]
    public class PurchasesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public PurchasesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetCustomerPurchases(Guid customerId)
        {
            var purchases = _serviceManager.Purchase.GetCustomerPurchases(customerId, trackChanges: false);
            return Ok(purchases);
        }

        [HttpGet("{purchaseId}", Name ="PurchaseById")]
        public IActionResult GetCustomerPurchase(Guid customerId, Guid purchaseId)
        {
            var purchase = _serviceManager.Purchase.GetCustomerPurchase(customerId, purchaseId, trackChanges: false);
            return Ok(purchase);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateCustomerPurchase(Guid customerId, [FromBody] PurchaseForCreationDTO purchaseForCreation)
        {
            var purchase = _serviceManager.Purchase.CreateCustomerPurchase(customerId, purchaseForCreation, trackChanges: false);
            return CreatedAtRoute("PurchaseById", new { customerId = purchase.CustomerId, purchaseId = purchase.PurchaseId }, purchase);
        }

        [HttpDelete("{purchaseId}")]
        public IActionResult DeleteCustomerPurchase(Guid customerId, Guid purchaseId)
        {
            _serviceManager.Purchase.DeleteCustomerPurchase(customerId, purchaseId, trackChanges : false);
            return NoContent();
        }

        [HttpPut("{purchaseId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult UpdateCustomerPurchase(Guid customerId, Guid purchaseId, [FromBody] PurchaseForUpdateDTO purchaseForUpdate)
        {
            var purchase = _serviceManager
                .Purchase
                .UpdateCustomerPurchase(customerId, purchaseId, purchaseForUpdate, customerTrackChanges: false, purchaseTrackChanges: true);
            return Ok(purchase);
        }
    }
}
