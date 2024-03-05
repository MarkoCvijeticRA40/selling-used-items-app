using System.ComponentModel.DataAnnotations;

namespace selling_used_items_app_backend.Validator.UserValidator
{
    public class UserDeleteValidator
    {
        private readonly ApplicationDbContext _dbContext;

        public UserDeleteValidator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ValidationResult ValidateUser(int userId)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.id == userId);
            if (existingUser == null)
            {
                return new ValidationResult($"User with ID {userId} does not exist.");
            }
            return ValidationResult.Success;
        }
    }
}