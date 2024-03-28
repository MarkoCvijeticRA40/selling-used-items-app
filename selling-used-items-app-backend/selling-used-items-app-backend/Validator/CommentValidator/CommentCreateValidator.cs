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

            if (_dbContext.Advertisements.FirstOrDefault(a => a.id == comment.advertisementId) == null)
            {
                return new ValidationResult("Invalid AdvertisementId. Advertisement does not exist.");
            }

            if (_dbContext.Users.FirstOrDefault(u => u.id == comment.creatorId) == null)
            {
                return new ValidationResult("Invalid CreatorId. Creator does not exist.");
            }

            if (_dbContext.Users.FirstOrDefault(u => u.id == comment.targetUserId) == null)
            {
                return new ValidationResult("Invalid TargetUserId. Target user does not exist.");
            }

            if (comment.rating < 1 || comment.rating > 5)
            {
                return new ValidationResult("Rating must be between 1 and 5.");
            }

            if (_dbContext.Comments.Any(c => c.advertisementId == comment.advertisementId && c.creatorId == comment.creatorId))
            {
                return new ValidationResult("Comment with the same AdvertisementId and CreatorId already exists.");
            }

            /*if (!_dbContext.Purchases.Any(p => p.userId == comment.creatorId && p.advertisementId == comment.advertisementId))
            {
                return new ValidationResult("Can not comment because you do not have purchase with these user!");
            }*/

            /*if(_dbContext.Comments.Any(c => c.isApproved == true)) {
                return new ValidationResult("Comment can not be approved!");
            }*/

            return ValidationResult.Success;
        }
    }
}
