using selling_used_items_app_backend.Enum;
using selling_used_items_app_backend.Model;
using System.ComponentModel.DataAnnotations;

namespace selling_used_items_app_backend.Validator.PurchaseValidator
{
    public class PurchaseCreateValidator
    {
        private readonly ApplicationDbContext _dbContext;

        public PurchaseCreateValidator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ValidationResult ValidatePurchase(Purchase purchase)
        {
            if (purchase == null)
            {
                return new ValidationResult("Purchase object is null.");
            }

            if (purchase.id != 0)
            {
                return new ValidationResult("ID should not be set for new purchases.");
            }

            if (_dbContext.Users.FirstOrDefault(u => u.id == purchase.userId) == null)
            {
                return new ValidationResult("Invalid userId. User does not exist.");
            }

            if (_dbContext.Advertisements.FirstOrDefault(a => a.id == purchase.advertisementId) == null)
            {
                return new ValidationResult("Invalid advertisementId. Advertisement does not exist.");
            }

            return ValidationResult.Success;
        }
    }
}
