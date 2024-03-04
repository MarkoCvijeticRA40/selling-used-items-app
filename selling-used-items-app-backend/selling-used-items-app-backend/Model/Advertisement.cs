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

    [Required(ErrorMessage = "Price is required")]
    public int price { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    public string name { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    public string description { get; set; }
    
    public DateTime dateCreated { get; } = DateTime.UtcNow;

    [Required(ErrorMessage = "Location is required")]
    public string location { get; set; }

    [ForeignKey("User")]
    public int userId { get; set; }

    [Required(ErrorMessage = "Status is required")]
    public AdvertisementStatus advertisementStatus { get; set; } = AdvertisementStatus.Available;
    }
}
