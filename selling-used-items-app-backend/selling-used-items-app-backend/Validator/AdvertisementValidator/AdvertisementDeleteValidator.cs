using System.ComponentModel.DataAnnotations;

namespace selling_used_items_app_backend.Validator.AdvertisementValidator
{
    public class AdvertisementDeleteValidator
    {
        private readonly ApplicationDbContext _dbContext;

        public AdvertisementDeleteValidator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ValidationResult ValidateAdvertisement(int advertisementId)
        {
            var existingAdvertisement = _dbContext.Advertisements.FirstOrDefault(a => a.id == advertisementId);
            if (existingAdvertisement == null)
            {
                return new ValidationResult($"Advertisement with ID {advertisementId} does not exist.");
            }
            return ValidationResult.Success;
        }
    }
}