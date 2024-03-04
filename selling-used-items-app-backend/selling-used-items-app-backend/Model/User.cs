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

        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string email { get; set; }
        
        [Required(ErrorMessage = "Role is required")]
        public UserRole userRole { get; set; }

        [Required(ErrorMessage = "Blocked status is required")]
        public bool isBlocked { get; set; } = false;
    }
}
