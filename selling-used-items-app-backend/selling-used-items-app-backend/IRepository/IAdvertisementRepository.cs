using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.IRepository
{
    public interface IAdvertisementRepository
    {
        IEnumerable<Advertisement> GetAll();
        Advertisement GetById(int id);
        void Create(Advertisement advertisement);
        void Update(Advertisement advertisement);
        void Delete(int id);
    }
}
