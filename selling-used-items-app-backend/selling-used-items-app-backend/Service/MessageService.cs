using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Repository;
using System.Collections.Generic;

namespace selling_used_items_app_backend.Service
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IEnumerable<Message> GetAll()
        {
            return _messageRepository.GetAll();
        }

        public void Send(Message message)
        {
            _messageRepository.Create(message);
        }

        public void Delete(int id)
        {
            _messageRepository.Delete(id);
        }
    }
}
