using System.Security.Cryptography;
using System.Text;
using selling_used_items_app_backend.Model;
using selling_used_items_app_backend.Repository;

namespace selling_used_items_app_backend.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService() { }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User Get(int id)
        {
            return _userRepository.Get(id);
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

        public User GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }

        public string GenerateRandomPassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashedBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void Block(int id)
        {
            var user = _userRepository.Get(id);
            if (user != null)
            {
                user.isBlocked = true;
                _userRepository.Update(user);
            }
        }

        public void Unblock(int id)
        {
            var user = _userRepository.Get(id);
            if (user != null)
            {
                user.isBlocked = false;
                _userRepository.Update(user);
            }
        }

        public string GetUserEmailById(int userId)
        {
            var user = _userRepository.Get(userId);
            return user != null ? user.email : null;
        }
    }
}
