using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selling_used_items_app_backend.Model
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string content { get; set; }

        [ForeignKey("Advertisement")]
        public int advertisementId { get; set; }

        [ForeignKey("User")]
        public int userId { get; set; }

        [Required]
        public double rating { get; set; }
    }
}
