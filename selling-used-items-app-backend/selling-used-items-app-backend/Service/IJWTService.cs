namespace selling_used_items_app_backend.Service
{
    public interface IJWTService
    {
        string GenerateToken(string email, string password);
    }
}
