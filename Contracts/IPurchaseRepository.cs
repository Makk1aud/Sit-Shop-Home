using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> GetCustomerPurchases(Guid customerId, bool trackChanges);
        Purchase GetCustomerPurchase(Guid customerId, Guid purchaseId, bool purchaseTrackChanges);
        void DeleteCustomerPurchase(Purchase purchase);
        void CreateCustomerPurchase(Guid customerId, Purchase purchase);
    }
}
