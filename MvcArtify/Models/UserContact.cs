using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcArtify.Models
{
    public class UserContact
    {
        [Key, Column(Order = 0)]
        public int UserID { get; set; }
        [Key, Column(Order = 1), MaxLength(20)]
        public string ContactInfo { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
