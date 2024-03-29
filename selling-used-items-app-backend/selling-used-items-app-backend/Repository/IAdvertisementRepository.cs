using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Repository
{
    public interface IAdvertisementRepository
    {
        IEnumerable<Advertisement> GetAll();
        Advertisement Get(int id);
        void Create(Advertisement advertisement);
        void Update(Advertisement advertisement);
        void Delete(int id);
        IEnumerable<Advertisement> GetByUserId(int userId);
        IEnumerable<Advertisement> GetAllAvailable();
    }
}
