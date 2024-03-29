using selling_used_items_app_backend.dto;
using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Repository;

namespace selling_used_items_app_backend.Service
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IAdvertisementRepository _advertisementRepository;

        public PurchaseService() { }

        public PurchaseService(IPurchaseRepository purchaseRepository, IAdvertisementRepository advertisementRepository)
        {
            _purchaseRepository = purchaseRepository ?? throw new ArgumentNullException(nameof(purchaseRepository));
            _advertisementRepository = advertisementRepository;
        }

        public IEnumerable<Purchase> GetAll()
        {
            return _purchaseRepository.GetAll();
        }

        public Purchase Get(int id)
        {
            return _purchaseRepository.Get(id);
        }

        public void Create(Purchase purchase)
        {
            if (purchase == null)
                throw new ArgumentNullException(nameof(purchase));

            _purchaseRepository.Create(purchase);
        }

        public void Update(Purchase purchase)
        {
            if (purchase == null)
                throw new ArgumentNullException(nameof(purchase));

            _purchaseRepository.Update(purchase);
        }

        public void Delete(int id)
        {
            _purchaseRepository.Delete(id);
        }

        public IEnumerable<AdvertisementPurchaseDTO> GetByUserId(int userId)
        {
            var purchases = _purchaseRepository.GetByUserId(userId);
            var advertisementPurchaseDTOs = new List<AdvertisementPurchaseDTO>();

            foreach (var purchase in purchases)
            {
                var advertisement = _advertisementRepository.Get(purchase.advertisementId);
                if (advertisement != null)
                {
                    var advertisementPurchaseDTO = new AdvertisementPurchaseDTO
                    {
                        purchaseId = purchase.id,
                        name = advertisement.name,
                        price = advertisement.price,
                        description = advertisement.description,
                        advertisementStatus = (int)advertisement.advertisementStatus
                    };

                    advertisementPurchaseDTOs.Add(advertisementPurchaseDTO);
                }
            }

            return advertisementPurchaseDTOs;
        }

        public int GetAdvertisementCreatorIdByPurchaseId(int purchaseId)
        {
            var purchase = _purchaseRepository.Get(purchaseId);
            if (purchase == null)
            {
                throw new Exception($"Purchase with id {purchaseId} not found.");
            }

            var advertisement = _advertisementRepository.Get(purchase.advertisementId);
            if (advertisement == null)
            {
                throw new Exception($"Advertisement with id {purchase.advertisementId} not found.");
            }

            return advertisement.userId;
        }
    }
}
