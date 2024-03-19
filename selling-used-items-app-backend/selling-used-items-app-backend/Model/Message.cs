using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace selling_used_items_app_backend.Model
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("User")]
        public int userSenderId { get; set; }

        [ForeignKey("User")]
        public int userReceiverId { get; set; }
        
        public string content { get; set; }
        
        public DateTime dateCreated { get; set; }
    }
}
