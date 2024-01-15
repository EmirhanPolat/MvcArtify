using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcArtify.Models
{
    public class Schedule
    {
        [Key, Column(Order = 0)]
        public int GalleryID { get; set; }
        [Key, Column(Order = 1)]
        public int ExhibitionID { get; set; }

        [ForeignKey("GalleryID")]
        public virtual Gallery Gallery { get; set; }
        [ForeignKey("ExhibitionID")]
        public virtual Exhibition Exhibition { get; set; }
    }
}
