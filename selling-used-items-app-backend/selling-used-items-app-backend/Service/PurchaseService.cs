using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Repository;

namespace selling_used_items_app_backend.Service
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService() { }

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository ?? throw new ArgumentNullException(nameof(purchaseRepository));
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
    }
}
