using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        void Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}
