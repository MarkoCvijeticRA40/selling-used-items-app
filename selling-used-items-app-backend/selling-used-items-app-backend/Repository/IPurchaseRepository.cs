using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Repository
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> GetAll();
        Purchase Get(int id);
        void Create(Purchase purchase);
        void Update(Purchase purchase);
        void Delete(int id);
    }
}
