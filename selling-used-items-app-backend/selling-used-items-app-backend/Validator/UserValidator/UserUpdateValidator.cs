using selling_used_items_app_backend.Model;
using System.ComponentModel.DataAnnotations;

namespace selling_used_items_app_backend.Validator.UserValidator
{
    public class UserUpdateValidator
    {
        private readonly ApplicationDbContext _dbContext;

        public UserUpdateValidator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ValidationResult ValidateUser(User user)
        {
            if (user == null)
            {
                return new ValidationResult("User object is null.");
            }

            if (!_dbContext.Users.Any(u => u.id == user.id))
            {
                return new ValidationResult($"User with ID {user.id} does not exist.");
            }

            if (string.IsNullOrWhiteSpace(user.name))
            {
                return new ValidationResult("Name is required.");
            }

            if (string.IsNullOrWhiteSpace(user.lastName))
            {
                return new ValidationResult("Last name is required.");
            }

            if (string.IsNullOrWhiteSpace(user.username))
            {
                return new ValidationResult("Username is required.");
            }

            if (string.IsNullOrWhiteSpace(user.password))
            {
                return new ValidationResult("Password is required.");
            }

            if (string.IsNullOrEmpty(user.email))
            {
                return new ValidationResult("Email is required.");
            }

            return ValidationResult.Success;
        }
    }
}