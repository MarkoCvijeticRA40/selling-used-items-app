using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        void Create(User user);
        void Update(User user);
        void Delete(int id);
        User GetByEmail(string email);
        string GenerateRandomPassword(int length);
        public string HashPassword(string password);
    }
}
