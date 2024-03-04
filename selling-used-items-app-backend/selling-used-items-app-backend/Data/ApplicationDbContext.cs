using Microsoft.EntityFrameworkCore;
using selling_used_items_app_backend.Model;

namespace selling_used_items_app_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        
        }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
