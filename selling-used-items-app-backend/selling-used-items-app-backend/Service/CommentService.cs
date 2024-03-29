using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Repository;

namespace selling_used_items_app_backend.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPurchaseService _purchaseService;

        public CommentService() { }

        public CommentService(ICommentRepository commentRepository, IPurchaseService purchaseService)
        {
            _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
            _purchaseService = purchaseService;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _commentRepository.GetAll();
        }

        public Comment Get(int id)
        {
            return _commentRepository.Get(id);
        }

        public void Create(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            var existingCommentWithPurchaseId = _commentRepository.GetAll().FirstOrDefault(c => c.purchaseId == comment.purchaseId);
            var advertisementCreatorId = _purchaseService.GetAdvertisementCreatorIdByPurchaseId(comment.purchaseId);
            comment.targetUserId = advertisementCreatorId;

            if (existingCommentWithPurchaseId != null)
            {
                throw new Exception($"Comment with {comment.purchaseId} already exist!.");
            }
            _commentRepository.Create(comment);
        }

        public void Update(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            _commentRepository.Update(comment);
        }

        public void Approve(Comment comment) {
            comment.isApproved = true;
            _commentRepository.Update(comment);
        }

        public void Decline(Comment comment) {
            comment.isApproved = false;
            _commentRepository.Update(comment);
        }

        public void Delete(int id)
        {
            _commentRepository.Delete(id);
        }

        public IEnumerable<Comment> GetAllByTargetUserId(int targetUserId)
        {
            return _commentRepository.GetAllByTargetUserId(targetUserId);
        }
    }
}
