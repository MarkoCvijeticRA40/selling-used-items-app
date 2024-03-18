using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Report> GetAll()
        {
            return _context.Reports.ToList();
        }

        public void Create(Report report)
        {
            _context.Reports.Add(report);
            _context.SaveChanges();
        }
    }
}
