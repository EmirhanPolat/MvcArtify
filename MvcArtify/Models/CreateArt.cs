using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcArtify.Models
{
    public class CreateArt
    {
        [Key, Column(Order = 0)]
        public int ArtistID { get; set; }
        [Key, Column(Order = 1)]
        public int ArtworkID { get; set; }

        [ForeignKey("ArtistID")]
        public virtual Artist Artist { get; set; }
        [ForeignKey("ArtworkID")]
        public virtual Artwork Artwork { get; set; }
    }
}
