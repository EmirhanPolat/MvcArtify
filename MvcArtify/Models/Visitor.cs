using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcArtify.Models
{
    public class Visitor
    {
        [Key, ForeignKey("User")]
        public int VisitorID { get; set; }

        public virtual User User { get; set; }
    }
}
