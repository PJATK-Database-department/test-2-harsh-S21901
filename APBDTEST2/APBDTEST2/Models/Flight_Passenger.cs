using System.ComponentModel.DataAnnotations.Schema;

namespace APBDTEST2.Models
{

    [Table("Flight_Passenger")]
    public class Flight_Passenger
    {
        public int IdFlight { get; set; }
        [ForeignKey("IdFlight")]
        public Flight Flight { get; set; }
        public int IdPassenger { get; set; }
        [ForeignKey("IdPassenger")]
        public Passenger Passenger { get; set; }
    }
}
