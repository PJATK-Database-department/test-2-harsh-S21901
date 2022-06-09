using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDTEST2.Models
{
    [Table("CityDict")]
    public class CityDict
    {
        [Key]
        public int IdCityDict { get; set; }
        [Required, MaxLength(30, ErrorMessage = "Not more than 30 characters")]
        public string City { get; set; }
        public ICollection<Flight> flights { get; set; } = new HashSet<Flight>();
    }
}