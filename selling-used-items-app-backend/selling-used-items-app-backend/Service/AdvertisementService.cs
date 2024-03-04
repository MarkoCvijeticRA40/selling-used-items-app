using selling_used_items_app_backend.IRepository;
using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Service
{
    public class AdvertisementService
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        public AdvertisementService()
        {

        }

        public AdvertisementService(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository ?? throw new ArgumentNullException(nameof(advertisementRepository));
        }

        public IEnumerable<Advertisement> GetAll()
        {
            return _advertisementRepository.GetAll();
        }

        public Advertisement GetById(int id)
        {
            return _advertisementRepository.GetById(id);
        }

        public void Create(Advertisement advertisement)
        {
            if (advertisement == null)
                throw new ArgumentNullException(nameof(advertisement));

            _advertisementRepository.Create(advertisement);
        }

        public void Update(Advertisement advertisement)
        {
            if (advertisement == null)
                throw new ArgumentNullException(nameof(advertisement));

            _advertisementRepository.Update(advertisement);
        }

        public void Delete(int id)
        {
            _advertisementRepository.Delete(id);
        }
    }
}