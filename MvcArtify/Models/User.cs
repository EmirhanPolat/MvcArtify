using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcArtify.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UId { get; set; }
        [MaxLength(50)]
        public string UName { get; set; }
        public int DigitalWallet { get; set; }
        public ICollection<ReviewComment> ReviewComments { get; internal set; }
        public ICollection<Review> Reviews { get; internal set; }
        public virtual ICollection<Artwork> BoughtArtworks { get; set; }
    }
}
