using selling_used_items_app_backend.Model;
using System.ComponentModel.DataAnnotations;

namespace selling_used_items_app_backend.Validator.PurchaseValidator
{
    public class PurchaseUpdateValidator
    {
        private readonly ApplicationDbContext _dbContext;

        public PurchaseUpdateValidator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ValidationResult ValidatePurchaseUpdate(Purchase purchase)
        {
            if (purchase == null)
            {
                return new ValidationResult("Purchase object is null.");
            }

            if (_dbContext.Purchases.FirstOrDefault(p => p.id == purchase.id) == null)
            {
                return new ValidationResult("Invalid purchase ID. Purchase does not exist.");
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
