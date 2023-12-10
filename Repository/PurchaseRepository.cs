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
            return;
        }

        public void DeleteCustomerPurchase(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public Purchase GetCustomerPurchase(Guid customerId, Guid purchaseId, bool purchaseTrackChanges)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Purchase> GetCustomerPurchases(Guid customerId, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
