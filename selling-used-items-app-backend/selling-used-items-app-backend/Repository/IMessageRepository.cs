using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Repository
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetAll();
        void Create(Message message);
        void Delete(int id);
    }
}