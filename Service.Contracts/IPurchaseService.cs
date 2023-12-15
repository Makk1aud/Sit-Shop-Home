using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPurchaseService
    {
        IEnumerable<PurchaseDTO> GetCustomerPurchases(Guid customerId, bool trackChanges);
        PurchaseDTO GetCustomerPurchase(Guid customerId, Guid purchaseId, bool trackChanges);
        PurchaseDTO UpdateCustomerPurchase(Guid customerId, Guid purchaseId, PurchaseForUpdateDTO purchaseForManipulation, bool customerTrackChanges, bool purchaseTrackChanges);
        void DeleteCustomerPurchase(Guid customerId, Guid purchaseId, bool trackChanges);
        PurchaseDTO CreateCustomerPurchase(Guid customerId, PurchaseForCreationDTO purchaseForCreation, bool trackChanges);
    }
}
