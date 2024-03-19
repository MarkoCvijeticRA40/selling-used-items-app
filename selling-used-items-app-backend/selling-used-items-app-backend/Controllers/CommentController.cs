using Microsoft.AspNetCore.Mvc;
using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Service;
using selling_used_items_app_backend.Validator.CommentValidator;
using System.ComponentModel.DataAnnotations;

namespace selling_used_items_app_backend.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly CommentCreateValidator _commentCreateValidator;
        private readonly CommentDeleteValidator _commentDeleteValidator;

        public CommentController(ICommentService commentService, CommentDeleteValidator commentDeleteValidator, CommentCreateValidator commentCreateValidator)
        {
            _commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
            _commentCreateValidator = commentCreateValidator;
            _commentDeleteValidator = commentDeleteValidator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Comment>> GetAllComments()
        {
            var comments = _commentService.GetAll();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public ActionResult<Comment> GetComment(int id)
        {
            var comment = _commentService.Get(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            var validationResult = _commentCreateValidator.ValidateComment(comment);
            if (validationResult != ValidationResult.Success)
            {
                return BadRequest(validationResult.ErrorMessage);
            }
            _commentService.Create(comment);
            return CreatedAtAction(nameof(GetComment), new { id = comment.id }, comment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var validationResult = _commentDeleteValidator.ValidateComment(id);
            if (validationResult != ValidationResult.Success)
            {
                return NotFound(validationResult.ErrorMessage);
            }
            _commentService.Delete(id);
            return NoContent();
        }

        [HttpGet("target-user/{targetUserId}")]
        public ActionResult<IEnumerable<Comment>> GetCommentsByTargetUserId(int targetUserId)
        {
            var comments = _commentService.GetAllByTargetUserId(targetUserId);
            return Ok(comments);
        }

        [HttpPatch("{id}/approve")]
        public IActionResult ApproveComment(int id)
        {
            var comment = _commentService.Get(id);
            if (comment == null)
            {
                return NotFound("Comment not found.");
            }

            if (comment.isApproved)
            {
                return BadRequest("Comment is already approved.");
            }

            comment.isApproved = true;
            _commentService.Update(comment);
            return Ok($"Comment with ID {id} has been approved.");
        }
    }
}