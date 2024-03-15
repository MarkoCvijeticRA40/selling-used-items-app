using selling_used_items_app_backend.Model;
using System.ComponentModel.DataAnnotations;

namespace selling_used_items_app_backend.Validator.CommentValidator
{
    public class CommentCreateValidator
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentCreateValidator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ValidationResult ValidateComment(Comment comment)
        {
            if (comment == null)
            {
                return new ValidationResult("Comment object is null.");
            }

            if (comment.id != 0)
            {
                return new ValidationResult("ID should not be set for new comments.");
            }

            if (string.IsNullOrWhiteSpace(comment.content))
            {
                return new ValidationResult("Content is required.");
            }

            if (comment.advertisementId <= 0 || _dbContext.Advertisements.FirstOrDefault(a => a.id == comment.advertisementId) == null)
            {
                return new ValidationResult("Invalid advertisementId. Advertisement does not exist.");
            }

            if (comment.userId <= 0 || _dbContext.Users.FirstOrDefault(u => u.id == comment.userId) == null)
            {
                return new ValidationResult("Invalid userId. User does not exist.");
            }

            if (comment.rating < 0 || comment.rating > 5)
            {
                return new ValidationResult("Rating must be between 0 and 5.");
            }

            return ValidationResult.Success;
        }
    }
}