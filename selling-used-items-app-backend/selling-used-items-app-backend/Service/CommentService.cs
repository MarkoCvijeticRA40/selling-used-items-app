using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Repository;

namespace selling_used_items_app_backend.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService() { }

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
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

            _commentRepository.Create(comment);
        }

        public void Update(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            _commentRepository.Update(comment);
        }

        public void Delete(int id)
        {
            _commentRepository.Delete(id);
        }
    }
}
