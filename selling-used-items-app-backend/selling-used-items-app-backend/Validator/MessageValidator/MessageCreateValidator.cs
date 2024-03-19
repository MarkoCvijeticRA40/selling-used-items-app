using System.ComponentModel.DataAnnotations;
using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Validator.MessageValidator
{
    public class MessageCreateValidator
    {
        private readonly ApplicationDbContext _dbContext;

        public MessageCreateValidator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ValidationResult ValidateMessage(Message message)
        {
            if (message == null)
            {
                return new ValidationResult("Message object is null.");
            }

            if (message.id != 0)
            {
                return new ValidationResult("ID should not be set for new messages.");
            }

            if (_dbContext.Users.FirstOrDefault(u => u.id == message.userSenderId) == null)
            {
                return new ValidationResult("Invalid sender userId. User does not exist.");
            }

            if (_dbContext.Users.FirstOrDefault(u => u.id == message.userReceiverId) == null)
            {
                return new ValidationResult("Invalid receiver userId. User does not exist.");
            }

            if (string.IsNullOrWhiteSpace(message.content))
            {
                return new ValidationResult("Message content is required.");
            }

            

            return ValidationResult.Success;
        }
    }
}
