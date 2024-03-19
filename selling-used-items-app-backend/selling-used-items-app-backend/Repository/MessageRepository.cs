using selling_used_items_app_backend.Model;
using System.Collections.Generic;
using System.Linq;

namespace selling_used_items_app_backend.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Message> GetAll()
        {
            return _context.Messages.ToList();
        }

        public void Create(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var message = _context.Messages.Find(id);
            if (message != null)
            {
                _context.Messages.Remove(message);
                _context.SaveChanges();
            }
        }
    }
}
