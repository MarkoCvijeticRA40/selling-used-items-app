namespace selling_used_items_app_backend.Service
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toAddress, string subject, string body);
    }

}