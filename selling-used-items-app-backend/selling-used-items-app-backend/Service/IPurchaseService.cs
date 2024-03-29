using selling_used_items_app_backend.dto;
using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Service
{
    public interface IPurchaseService
    {
        IEnumerable<Purchase> GetAll();
        Purchase Get(int id);
        void Create(Purchase purchase);
        void Update(Purchase purchase);
        void Delete(int id);
        IEnumerable<AdvertisementPurchaseDTO> GetByUserId(int userId);
    }
}
