namespace selling_used_items_app_backend.Service
{
    public interface IJWTService
    {
        public string GenerateToken(string email, string password, string role);
        public bool isTokenExpired(string token);
    }
}
