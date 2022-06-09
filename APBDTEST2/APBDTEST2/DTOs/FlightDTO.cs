namespace APBDTEST2.DTOs
{
    public class FlightDTO
    {
       
        public int IdFlight { get; set; }
        public DateTime FlightDate { get; set; }
        public string Comments { get; set; }

        public int IdPlane { get; set; }

        public int IdCityDict { get; set; }
    }
}
