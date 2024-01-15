using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcArtify.Models
{
    public class Artwork
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArtworkID { get; set; }
        [MaxLength(50)]
        public string ATitle { get; set; }
        [MaxLength(50)]
        public string ArtStyle { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
        public string ImagePath { get; set; } // BLOB is typically represented as a byte array
        [MaxLength(50)]
        public string Description { get; set; }
        public int VisitorID { get; set; }
        public DateTime SaleDate { get; set; }
        public float SalePrice { get; set; }
        public int GalleryID { get; set; }
        public int ExhibitionID { get; set; }


        [ForeignKey("GalleryID")]
        public virtual Gallery Gallery { get; set; }
        [ForeignKey("ExhibitionID")]
        public virtual Exhibition Exhibition { get; set; }

        public virtual ICollection<CreateArt> Creators { get; set; }
        public ICollection<ReviewComment> Comments { get; internal set; }
        public ICollection<Review> Reviews { get; internal set; }
    }
}
