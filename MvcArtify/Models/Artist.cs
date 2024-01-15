using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcArtify.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [MaxLength(50)]
        public string Bio { get; set; }

        [MaxLength(50)]
        public string Identifier { get; set; }

        [MaxLength(50)]
        public string ArtistStyle { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<CreateArt> CreatedArt { get; set; }
    }
}
