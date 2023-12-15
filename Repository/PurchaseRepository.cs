using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PurchaseRepository : RepositoryBase<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(SitshophomeContext sitshophomeContext)
            : base(sitshophomeContext)
        {
        }

        public void CreateCustomerPurchase(Guid customerId, Purchase purchase)
        {
            purchase.CustomerId = customerId;
            Create(purchase);
        }

        public void DeleteCustomerPurchase(Purchase purchase) => Delete(purchase);

        public Purchase GetCustomerPurchase(Guid customerId, Guid purchaseId, bool purchaseTrackChanges) =>
            FindByContidion(x => x.PurchaseId.Equals(purchaseId) && 
            x.CustomerId.Equals(customerId), purchaseTrackChanges)
            .SingleOrDefault();

        public IEnumerable<Purchase> GetCustomerPurchases(Guid customerId, bool trackChanges) =>
            FindByContidion(x => x.CustomerId.Equals(customerId), trackChanges)
            .ToList();
    }
}
