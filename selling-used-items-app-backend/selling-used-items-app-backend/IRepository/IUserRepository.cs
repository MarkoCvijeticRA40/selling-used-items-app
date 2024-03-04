using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.IRepository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}
