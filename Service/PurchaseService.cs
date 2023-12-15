using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Service.Utility;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly EntityChecker _entityChecker;

        public PurchaseService(IRepositoryManager repositoryManager, IMapper mapper, EntityChecker entityChecker)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _entityChecker = entityChecker;
        }

        public PurchaseDTO CreateCustomerPurchase(Guid customerId, PurchaseForCreationDTO purchaseForCreation, bool trackChanges)
        {
            _entityChecker.GetCustomerAndCheckIfItExist(customerId, trackChanges);
            _entityChecker.GetProductAndCheckIfItExist((Guid)purchaseForCreation.ProductId, trackChanges);
            
            var purchase = _mapper.Map<Purchase>(purchaseForCreation);
            _repositoryManager.Purchase.CreateCustomerPurchase(customerId, purchase);
            _repositoryManager.Save();

            var purchaseToReturn = _mapper.Map<PurchaseDTO>(purchase);
            return purchaseToReturn;
        }

        public void DeleteCustomerPurchase(Guid customerId, Guid purchaseId, bool trackChanges)
        {
            _entityChecker.GetCustomerAndCheckIfItExist(customerId, trackChanges);
            var purchase = _entityChecker.GetPurchaseAndCheckIfItExist(customerId, purchaseId, trackChanges);

            _repositoryManager.Purchase.DeleteCustomerPurchase(purchase);
            _repositoryManager.Save();
        }

        public PurchaseDTO GetCustomerPurchase(Guid customerId, Guid purchaseId, bool trackChanges)
        {
            _entityChecker.GetCustomerAndCheckIfItExist(customerId, trackChanges);
            var purchase = _entityChecker.GetPurchaseAndCheckIfItExist(customerId, purchaseId, trackChanges);
            var purchaseToReturn = _mapper.Map<PurchaseDTO>(purchase);
            return purchaseToReturn;
        }

        public IEnumerable<PurchaseDTO> GetCustomerPurchases(Guid customerId, bool trackChanges)
        {
            _entityChecker.GetCustomerAndCheckIfItExist(customerId, trackChanges);
            var purchases = _repositoryManager.Purchase.GetCustomerPurchases(customerId, trackChanges);
            var purchasesToReturn = _mapper.Map<IEnumerable<PurchaseDTO>>(purchases);
            return purchasesToReturn;
        }

        public PurchaseDTO UpdateCustomerPurchase(Guid customerId, Guid purchaseId, PurchaseForUpdateDTO purchaseForManipulation, bool customerTrackChanges, bool purchaseTrackChanges)
        {
            _entityChecker.GetCustomerAndCheckIfItExist(customerId, customerTrackChanges);
            var purchase = _repositoryManager.Purchase.GetCustomerPurchase(customerId, purchaseId, purchaseTrackChanges);
            _mapper.Map(purchaseForManipulation, purchase);
            _repositoryManager.Save();

            var purchaseToReturn = _mapper.Map<PurchaseDTO>(purchase);
            return purchaseToReturn;
        }
    }
}
