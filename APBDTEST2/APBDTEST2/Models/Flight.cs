using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDTEST2.Models
{
    [Table("Flight")]
    public class Flight
    {
        [Key]
        public int IdFlight { get; set; }
        public DateTime FlightDate { get; set; }
        [MaxLength(200, ErrorMessage = "Not more than 200 characters")]
        public string Comments { get; set; }

        public int IdPlane { get; set; }
        [ForeignKey("IdPlane")]
        public Plane Plane { get; set; }

        public int IdCityDict { get; set; }
        [ForeignKey("IdCityDict")]
        public CityDict CityDict { get; set; }

        public ICollection<Flight_Passenger> flight_Passengers { get; set; } = new HashSet<Flight_Passenger>();
    }
    }