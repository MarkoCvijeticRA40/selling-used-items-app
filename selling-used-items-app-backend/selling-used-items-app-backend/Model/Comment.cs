using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selling_used_items_app_backend.Model
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("User")]
        public int creatorId { get; set; }

        [ForeignKey("User")]
        public int targetUserId { get; set; }

        [ForeignKey("Advertisement")]
        public int advertisementId { get; set; }

        public string message { get; set; } 

        public int rating { get; set; }
        
        public Boolean isApproved { get; set;}
    }
}
