using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcArtify.Models
{
    public class ClosedDay
    {
        [Key, Column(Order = 0)]
        public int GalleryID { get; set; }
        [Key, Column(Order = 1), MaxLength(10)]
        public string ClosedDayDate { get; set; }

        [ForeignKey("GalleryID")]
        public virtual Gallery Gallery { get; set; }
    }
}
