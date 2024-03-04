using selling_used_items_app_backend;
using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Repository
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly ApplicationDbContext _context;

        public AdvertisementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Advertisement> GetAll()
        {
            return _context.Advertisements.ToList();
        }

        public Advertisement Get(int id)
        {
            return _context.Advertisements.Find(id);
        }

        public void Create(Advertisement advertisement)
        {
            _context.Advertisements.Add(advertisement);
            _context.SaveChanges();
        }

        public void Update(Advertisement advertisement)
        {
            _context.Advertisements.Update(advertisement);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var advertisement = _context.Advertisements.Find(id);
            if (advertisement != null)
            {
                _context.Advertisements.Remove(advertisement);
                _context.SaveChanges();
            }
        }
    }
}
