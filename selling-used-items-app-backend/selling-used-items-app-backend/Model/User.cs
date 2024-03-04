using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using selling_used_items_app_backend.Enum;

namespace selling_used_items_app_backend.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
        [Required]
        public string name { get; set; }
        
        [Required]
        public string lastName { get; set; }
        
        [Required]
        public string username { get; set; }
        
        [Required]
        public string password { get; set; }
        
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public UserRole role { get; set; }
    }
}
