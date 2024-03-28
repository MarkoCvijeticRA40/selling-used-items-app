using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Service
{
    public interface IAdvertisementService
    {
        IEnumerable<Advertisement> GetAll();
        Advertisement Get(int id);
        void Create(Advertisement advertisement);
        void Update(Advertisement advertisement);
        void Delete(int id);
        IEnumerable<Advertisement> Search(string name, char? firstLetter, string sortBy);
        //void Sell(int advertisementId);
         IEnumerable<Advertisement> GetByUserId(int userId);
    }
}
