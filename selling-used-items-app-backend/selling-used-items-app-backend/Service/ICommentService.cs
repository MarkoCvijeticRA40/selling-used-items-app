using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Service
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetAll();
        Comment Get(int id);
        void Create(Comment comment);
        void Update(Comment comment);
        void Delete(int id);
        public IEnumerable<Comment> GetAllByTargetUserId(int targetUserId);
    }
}
