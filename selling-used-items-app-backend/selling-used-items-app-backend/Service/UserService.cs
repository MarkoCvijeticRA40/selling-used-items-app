using selling_used_items_app_backend.IRepository;
using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Service
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {

        }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Create(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _userRepository.Create(user);
        }

        public void Update(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _userRepository.Update(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
