using Microsoft.AspNetCore.Mvc;
using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Service;
using selling_used_items_app_backend.Validator.MessageValidator;
using System.ComponentModel.DataAnnotations;

namespace selling_used_items_app_backend.Controllers
{
    [ApiController]
    [Route("api/messages")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IEmailService _emailService;
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserService _userService;
        private readonly MessageCreateValidator _messageCreateValidator;

        public MessageController(IUserService userService, ApplicationDbContext dbContext, IMessageService messageService, IEmailService emailService, MessageCreateValidator messageCreateValidator)
        {
            _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _messageCreateValidator = messageCreateValidator;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message message)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var validationResult = _messageCreateValidator.ValidateMessage(message);
                    if (validationResult != ValidationResult.Success)
                    {
                        dbContextTransaction.Rollback();
                        return BadRequest(validationResult.ErrorMessage);
                    }

                    _messageService.Send(message);

                    if (message.id == 0) 
                    {
                        dbContextTransaction.Rollback();
                        return BadRequest("Failed to send message.");
                    }

                    var receiverEmail = _userService.GetUserEmailById(message.userReceiverId); 
                    var senderEmail = _userService.GetUserEmailById(message.userSenderId);
                    if (!string.IsNullOrEmpty(receiverEmail))
                    {
                        await _emailService.SendEmailAsync(receiverEmail, "New message received", $"{message.content}<br />Replay to {senderEmail}<br /><br />Please do not reply to this message!");
                    }

                    dbContextTransaction.Commit();
                    return Ok("Message sent successfully.");
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
