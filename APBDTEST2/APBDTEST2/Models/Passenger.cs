using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDTEST2.Models
{
    [Table("Passenger")]
    public class Passenger
    {
        [Key]
        public int IdPassenger { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Not more than 50 characters")]
        public string FirstName { get; set; }
        [Required, MaxLength(60, ErrorMessage = "Not more than 60 characters")]
        public string LastName { get; set; }
        [Required, MaxLength(20, ErrorMessage = "Not more than 20 characters")]
        public string PassportNum { get; set; }
        public ICollection<Flight_Passenger> flight_Passengers { get; set; } = new HashSet<Flight_Passenger>();
    }
}
