using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }

        public Comment Get(int id)
        {
            return _context.Comments.Find(id);
        }

        public void Create(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void Update(Comment comment)
        {
            _context.Comments.Update(comment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Comment> GetAllByTargetUserId(int targetUserId)
        {
            return _context.Comments.Where(c => c.targetUserId == targetUserId).ToList();
        }
    }
}
