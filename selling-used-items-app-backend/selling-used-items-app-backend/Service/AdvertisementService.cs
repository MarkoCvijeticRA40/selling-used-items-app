using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Repository;

namespace selling_used_items_app_backend.Service
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        public AdvertisementService() { }

        public AdvertisementService(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository ?? throw new ArgumentNullException(nameof(advertisementRepository));
        }

        public IEnumerable<Advertisement> GetAll()
        {
            return _advertisementRepository.GetAll();
        }

        public Advertisement Get(int id)
        {
            return _advertisementRepository.Get(id);
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

        public IEnumerable<Advertisement> Search(string name, char? firstLetter, decimal? startPrice, decimal? endPrice)
        {
            var advertisements = _advertisementRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(name))
            {
                advertisements = advertisements.Where(advertisement => advertisement.name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            if (firstLetter != null)
            {
                advertisements = advertisements.Where(advertisement => advertisement.name.StartsWith(firstLetter.ToString(), StringComparison.OrdinalIgnoreCase));
            }

            if (startPrice != null)
            {
                advertisements = advertisements.Where(advertisement => advertisement.price >= startPrice);
            }

            if (endPrice != null)
            {
                advertisements = advertisements.Where(advertisement => advertisement.price <= endPrice);
            }

            advertisements = advertisements.OrderBy(advertisement => advertisement.price);

            return advertisements;
        }
    }
}