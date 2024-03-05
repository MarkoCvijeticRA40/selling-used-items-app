using System.ComponentModel.DataAnnotations;

namespace selling_used_items_app_backend.Validator.CommentValidator
{
    public class CommentDeleteValidator
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentDeleteValidator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ValidationResult ValidateComment(int commentId)
        {
            var existingComment = _dbContext.Comments.FirstOrDefault(c => c.id == commentId);
            if (existingComment == null)
            {
                return new ValidationResult($"Comment with ID {commentId} does not exist.");
            }
            return ValidationResult.Success;
        }
    }
}