using selling_used_items_app_backend.Enum;
using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Repository;
using selling_used_items_app_backend.UOW;

namespace selling_used_items_app_backend.Service
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        public AdvertisementService() { }

        public AdvertisementService(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;

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

        public IEnumerable<Advertisement> Search(string name, char? firstLetter, string sortBy)
        {
            var advertisements = _advertisementRepository.GetAllAvailable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                advertisements = advertisements.Where(advertisement => advertisement.name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            if (firstLetter != null)
            {
                advertisements = advertisements.Where(advertisement => advertisement.name.StartsWith(firstLetter.ToString(), StringComparison.OrdinalIgnoreCase));
            }

            if(!string.IsNullOrWhiteSpace(sortBy)) 
            {   
                if(sortBy.Equals("PriceASC")) {
                    advertisements = advertisements.OrderBy(advertisement => advertisement.price);
                }

                if(sortBy.Equals("PriceDESC")) {
                    advertisements = advertisements.OrderByDescending(advertisement => advertisement.price);
                }

                if(sortBy.Equals("NameASC")) {
                    advertisements = advertisements.OrderBy(advertisement => advertisement.name);
                }

                if(sortBy.Equals("NameDESC")) {
                    advertisements = advertisements.OrderByDescending(advertisement => advertisement.name);
                }
            }
            return advertisements;
        }

        public IEnumerable<Advertisement> GetByUserId(int userId)
        {
            return _advertisementRepository.GetByUserId(userId);
        }

        public IEnumerable<Advertisement> GetAllAvailable()
        {
            return _advertisementRepository.GetAllAvailable();
        }
    }
}