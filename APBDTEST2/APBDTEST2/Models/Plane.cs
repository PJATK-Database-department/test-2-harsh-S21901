using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDTEST2.Models
{
    [Table("Plane")]
    public class Plane
    {
        [Key]
        [Required]
        public int IdPlane { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Not more than 50 characters")]
        public string Name { get; set; }
        [Required]
        public int MaxSeats { get; set; }
        public ICollection<Flight> flights { get; set; } = new HashSet<Flight>();
    }
}
