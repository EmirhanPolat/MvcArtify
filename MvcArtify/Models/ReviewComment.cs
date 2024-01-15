using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcArtify.Models
{
    public class ReviewComment
    {
        [Key, Column(Order = 0)]
        public int UserID { get; set; }
        [Key, Column(Order = 1)]
        public int ArtworkID { get; set; }
        [Key, Column(Order = 2), MaxLength(50)]
        public string Comment { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        [ForeignKey("ArtworkID")]
        public virtual Artwork Artwork { get; set; }
    }
}
