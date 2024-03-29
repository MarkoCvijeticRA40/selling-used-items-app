using selling_used_items_app_backend.Enum;

namespace selling_used_items_app_backend.Service
{
    public interface IJWTService
    {
        string GenerateToken(string email, String userRole, int userId);
        public bool isTokenExpired(string token);
    }
}
