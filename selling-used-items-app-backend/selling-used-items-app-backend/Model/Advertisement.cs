using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using selling_used_items_app_backend.Enum;

namespace selling_used_items_app_backend.Model
{
    public class Advertisement
    { 
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Required]
    public int price { get; set; }
    
    [Required]
    public string name { get; set; }
    
    [Required]
    public string description { get; set; }
    
    public DateTime dateCreated { get; } = DateTime.UtcNow;

    [Required]
    public string location { get; set; }

    [ForeignKey("User")]
    public int userId { get; set; }

    [Required]
    public AdvertisementStatus advertisementStatus { get; set; }
    }
}
