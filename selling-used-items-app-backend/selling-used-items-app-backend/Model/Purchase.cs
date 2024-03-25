using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using selling_used_items_app_backend.Enum;

namespace selling_used_items_app_backend.Model
{
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("User")]
        public int userId { get; set; }

        [ForeignKey("Advertisement")]
        public int advertisementId { get; set; }
    }
}
