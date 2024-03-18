using selling_used_items_app_backend.Model;
using System.ComponentModel.DataAnnotations;

namespace selling_used_items_app_backend.Validator.AdvertisementValidator
{
    public class AdvertisementCreateValidator
    {
        private readonly ApplicationDbContext _dbContext;

        public AdvertisementCreateValidator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ValidationResult ValidateAdvertisement(Advertisement advertisement)
        {
            if (advertisement == null)
            {
                return new ValidationResult("Advertisement object is null.");
            }

            if (advertisement.id != 0)
            {
                return new ValidationResult("ID should not be set for new advertisements.");
            }

            if (advertisement.price <= 0)
            {
                return new ValidationResult("Price must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(advertisement.name))
            {
                return new ValidationResult("Name is required.");
            }

            if (string.IsNullOrWhiteSpace(advertisement.description))
            {
                return new ValidationResult("Description is required.");
            }

            if (string.IsNullOrWhiteSpace(advertisement.location))
            {
                return new ValidationResult("Location is required.");
            }

            if (advertisement.userId <= 0 || _dbContext.Users.FirstOrDefault(u => u.id == advertisement.userId) == null)
            {
                return new ValidationResult("Invalid userId. User does not exist.");
            }

            return ValidationResult.Success;
        }
    }
}
