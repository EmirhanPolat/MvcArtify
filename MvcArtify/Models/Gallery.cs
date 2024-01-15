using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcArtify.Models
{
    public class Gallery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GalleryID { get; set; }
        [MaxLength(50)]
        public string GName { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
    }
}
