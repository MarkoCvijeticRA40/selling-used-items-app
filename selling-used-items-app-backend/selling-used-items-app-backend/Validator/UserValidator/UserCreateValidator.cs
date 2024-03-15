using selling_used_items_app_backend.Model;
using System.ComponentModel.DataAnnotations;

namespace selling_used_items_app_backend.Validator.UserValidator
{
    public class UserCreateValidator
    {
        private readonly ApplicationDbContext _dbContext;

        public UserCreateValidator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ValidationResult ValidateUser(User user)
        {
            if (user == null)
            {
                return new ValidationResult("User object is null.");
            }

            if (user.id != 0)
            {
                return new ValidationResult("ID should not be set for new users.");
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

            if (_dbContext.Users.Any(u => u.email == user.email && u.id != user.id))
            {
                return new ValidationResult("Email already exists.");
            }

            if (user.isBlocked)
            {
                return new ValidationResult("Blocked status cannot be set during user creation.");
            }

            //Dodati za status
            //Dodati za isActive

            return ValidationResult.Success;
        }
    }
}