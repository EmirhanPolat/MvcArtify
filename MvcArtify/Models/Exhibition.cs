using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcArtify.Models
{
    public class Exhibition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExhibitionID { get; set; }
        [MaxLength(50)]
        public string ETitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [MaxLength(50)]
        public string Location { get; set; }

        public virtual ICollection<Artwork> Artworks { get; set; }
        public int GalleryID { get; set; } // Foreign key property
        public virtual Gallery Gallery { get; set; }
    }
}
