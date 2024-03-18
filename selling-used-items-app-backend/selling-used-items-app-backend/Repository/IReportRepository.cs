using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Repository
{
    public interface IReportRepository
    {
        IEnumerable<Report> GetAll();
        public void Create(Report report);
    }
}
