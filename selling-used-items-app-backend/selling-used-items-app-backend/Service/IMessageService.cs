using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Service
{
    public interface IMessageService
    {
        IEnumerable<Message> GetAll();
        void Send(Message message);
        void Delete(int id);
    }
}
