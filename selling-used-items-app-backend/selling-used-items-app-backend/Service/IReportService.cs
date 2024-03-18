using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Service
{
    public interface IReportService
    {
        IEnumerable<Report> GetAll();
        public void Create(Report report);
    }
}
