using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Purchase> GetAll()
        {
            return _context.Purchases.ToList();
        }

        public Purchase Get(int id)
        {
            return _context.Purchases.Find(id);
        }

        public void Create(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            _context.SaveChanges();
        }

        public void Update(Purchase purchase)
        {
            _context.Purchases.Update(purchase);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var purchase = _context.Purchases.Find(id);
            if (purchase != null)
            {
                _context.Purchases.Remove(purchase);
                _context.SaveChanges();
            }
        }
    }
}
