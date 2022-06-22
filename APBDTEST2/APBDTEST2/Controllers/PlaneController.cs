using APBDTEST2.DTOs;
using APBDTEST2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBDTEST2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaneController : ControllerBase
    {
        private readonly s21901Context _context;

        public PlaneController(s21901Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("FlightInfo")]
        public async Task<IActionResult> GetFlightInfo(int Idflight, string city)
        {
            var CheckPassenger = _context.flights.FirstOrDefault(x=> x.IdFlight == Idflight);
            if (CheckPassenger == null) return NotFound("Flight  Doesn't exist");

            var result=_context.flight_Passengers.OrderBy(y => y.Flight.FlightDate).Where(x => x.Flight.CityDict.City == city)
                .Select(x => new
                {
                    Idpassenger =x.Passenger.IdPassenger,
                    firstName =x.Passenger.FirstName,
                    lastName=x.Passenger.LastName,
                    passportNum= x.Passenger.PassportNum,
                    flightdate =x.Flight.FlightDate,
                    comment = x.Flight.Comments,
                    idflight = x.Flight.IdFlight,
                    idPlane = x.Flight.IdPlane,
                    idCityDict = x.Flight.IdCityDict

                })
                ;

            return Ok(result);

        }

        [HttpPost]
        [Route("AssignFlight")]
        public async Task<IActionResult> AssignFlight(FlightDTO flight)
        {
            var checkFlight = _context.flights.FirstOrDefault(x=> x.IdFlight == flight.IdFlight);
            if (checkFlight != null) return BadRequest($"Flight with Id {flight.IdFlight} already exists");

            var CheckPlane = _context.flights.Where(x=> x.IdFlight == flight.IdFlight).FirstOrDefault(x=> x.IdPlane == flight.IdPlane  && x.FlightDate == DateTime.Now);
            if (CheckPlane != null)
            {
                return BadRequest($"plane with id {flight.IdPlane} is already assigned");
            }

            else
            {
                var newFlight = new Flight { 
                    
                    IdFlight = flight.IdFlight,
                    FlightDate=flight.FlightDate,
                    Comments=flight.Comments,
                    IdPlane=flight.IdPlane,
                    IdCityDict=flight.IdCityDict,
                    };
                _context.flights.Add(newFlight);
                await _context.SaveChangesAsync();


            }

            return Ok();

        }

    }
}
