using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using selling_used_items_app_backend.Enum;
using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Service;
using selling_used_items_app_backend.UOW;
using selling_used_items_app_backend.Validator.UserValidator;
using System.ComponentModel.DataAnnotations;

namespace selling_used_items_app_backend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly UserCreateValidator _createUserValidator;
        private readonly UserUpdateValidator _updateUserValidator;
        private readonly UserDeleteValidator _deleteUserValidator;
        private readonly IJWTService _jwtService;
        private readonly ApplicationDbContext _dbContext;

        public UserController(IEmailService emailService,ApplicationDbContext dbContext, IJWTService jwtService, IUserService userService, UserCreateValidator createUserValidator, UserUpdateValidator updateUserValidator, UserDeleteValidator deleteUserValidator)
        {
            _userService = userService;
            _emailService = emailService;
            _createUserValidator = createUserValidator;
            _updateUserValidator = updateUserValidator;
            _deleteUserValidator = deleteUserValidator;
            _dbContext = dbContext;
            _jwtService = jwtService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, User user)
        {
            if (id != user.id)
            {
                return BadRequest("ID in the request path does not match the ID in the request body.");
            }
            var validationResult = _updateUserValidator.ValidateUser(user);
            if (validationResult != ValidationResult.Success)
            {
                return BadRequest(validationResult.ErrorMessage);
            }
            _userService.Update(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var validationResult = _deleteUserValidator.ValidateUser(id);
            if (validationResult != ValidationResult.Success)
            {
                return NotFound(validationResult.ErrorMessage);
            }
            _userService.Delete(id);
            return NoContent();
        }

        [HttpPost("generate-token")]
        public IActionResult GenerateToken(string email, string password, string role)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Email and password are required.");
            }
            string token = _jwtService.GenerateToken(email, password, role);
            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password, string role)
        {
            var user = _userService.GetByEmail(email);
            if (user == null)
            {
                return Unauthorized("Wrong credentials!");
            }

            string hashedPassword = _userService.HashPassword(password);

            if (user.password != hashedPassword)
            {
                return Unauthorized("Wrong credentials!");
            }

            var token = _jwtService.GenerateToken(email, password, role);
            return Ok(new { Token = token });
        }

       [HttpPost("register")]
        public IActionResult Create(User user)
        {       
            using (var unitOfWork = new UnitOfWork(_dbContext))
            {
                var validationResult = _createUserValidator.ValidateUser(user);
                if (validationResult != ValidationResult.Success)
                {
                    return BadRequest(validationResult.ErrorMessage);
                }
                
                try
                {
                    unitOfWork.BeginTransaction();
                    user.password = _userService.HashPassword(user.password);
                    _userService.Create(user);
                    _emailService.SendEmailAsync(user.email, "Welcome to our application!", "Thank you for registration!");
                    unitOfWork.CommitTransaction();
                    return CreatedAtAction(nameof(Get), new { id = user.id }, user);
                }
                catch (Exception ex)
                {
                    unitOfWork.RollbackTransaction();
                    return StatusCode(500, "Error: " + ex.Message);
                }
            }
        }

        [HttpPatch("forgot-password")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                var user = _userService.GetByEmail(email);
                if (user == null)
                {
                    return Ok("If the email address exists in our records, we have sent an email with instructions to reset your password.");
                }
                string newPassword = _userService.GenerateRandomPassword(10);

                user.password = newPassword;
                _userService.Update(user);

                user.password = _userService.HashPassword(newPassword);
                _userService.Update(user);

                _emailService.SendEmailAsync(email, "Your New Password", $"Your new password is: {newPassword}");

                return Ok("If the email address exists in our records, we have sent an email with instructions to reset your password.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error: " + ex.Message);
            }
        }

        [HttpPatch("{id}/block")]
        public IActionResult BlockUser(int id)
        {
            var user = _userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            var validationResult = _updateUserValidator.ValidateUser(user);
            if (validationResult != ValidationResult.Success)
            {
                return BadRequest(validationResult.ErrorMessage);
            }

            user.isBlocked = true;
            _userService.Update(user);

            return Ok($"User with ID {id} has been blocked.");
        }

        [HttpPatch("{id}/unblock")]
        public IActionResult UnblockUser(int id)
        {
            var user = _userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            var validationResult = _updateUserValidator.ValidateUser(user);
            if (validationResult != ValidationResult.Success)
            {
                return BadRequest(validationResult.ErrorMessage);
            }

            user.isBlocked = false;
            _userService.Update(user);

            return Ok($"User with ID {id} has been unblocked.");
        }
    }
}
