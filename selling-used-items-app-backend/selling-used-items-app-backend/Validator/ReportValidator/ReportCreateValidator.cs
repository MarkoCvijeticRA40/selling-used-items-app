using System.ComponentModel.DataAnnotations;
using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Validator.ReportValidator
{
    public class ReportCreateValidator
    {
        private readonly ApplicationDbContext _dbContext;

        public ReportCreateValidator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ValidationResult ValidateReport(Report report)
        {
            if (report == null)
            {
                return new ValidationResult("Report object is null.");
            }

            if (report.id != 0)
            {
                return new ValidationResult("ID should not be set for new reports");
            }

            if (string.IsNullOrWhiteSpace(report.reason))
            {
                return new ValidationResult("Reason is required.");
            }

            if (_dbContext.Users.FirstOrDefault(u => u.id == report.userId) == null)
            {
                return new ValidationResult("Invalid userId. User does not exist.");
            }
            
            return ValidationResult.Success;
        }
    }
}
