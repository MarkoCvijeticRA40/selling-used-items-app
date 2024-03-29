using selling_used_items_app_backend.Model;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

            if (string.IsNullOrWhiteSpace(comment.message))
            {
                return new ValidationResult("Message is required.");
            }

            if (_dbContext.Users.FirstOrDefault(u => u.id == comment.creatorId) == null)
            {
                return new ValidationResult("Invalid CreatorId. Creator does not exist.");
            }

            if (comment.rating < 1 || comment.rating > 5)
            {
                return new ValidationResult("Rating must be between 1 and 5.");
            }
            
            return ValidationResult.Success;
        }
    }
}
