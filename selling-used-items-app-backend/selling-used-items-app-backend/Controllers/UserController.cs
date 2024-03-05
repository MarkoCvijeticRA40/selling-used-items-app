using Microsoft.AspNetCore.Mvc;
using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Service;
using selling_used_items_app_backend.Validator.UserValidator;
using System.ComponentModel.DataAnnotations;

namespace selling_used_items_app_backend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserCreateValidator _createUserValidator;
        private readonly UserUpdateValidator _updateUserValidator;
        private readonly UserDeleteValidator _deleteUserValidator;


        public UserController(IUserService userService, UserCreateValidator createUserValidator, UserUpdateValidator updateUserValidator, UserDeleteValidator deleteUserValidator)
        {
            _userService = userService;
            _createUserValidator = createUserValidator;
            _updateUserValidator = updateUserValidator;
            _deleteUserValidator = deleteUserValidator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
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

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            var validationResult = _createUserValidator.ValidateUser(user);
            if (validationResult != ValidationResult.Success)
            {
                return BadRequest(validationResult.ErrorMessage);
            }
            _userService.Create(user);
            return CreatedAtAction(nameof(Get), new { id = user.id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
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
        public IActionResult DeleteUser(int id)
        {
            var validationResult = _deleteUserValidator.ValidateUser(id);
            if (validationResult != ValidationResult.Success)
            {
                return NotFound(validationResult.ErrorMessage);
            }
            _userService.Delete(id);
            return NoContent();
        }

    }
}
