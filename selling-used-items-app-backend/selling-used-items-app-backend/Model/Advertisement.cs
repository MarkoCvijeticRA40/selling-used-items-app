using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace selling_used_items_app_backend.Model
{
    public class Advertisement
    { 
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    public string description { get; set; }
    }
}
