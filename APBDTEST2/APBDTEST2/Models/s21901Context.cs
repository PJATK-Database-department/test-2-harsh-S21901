using Microsoft.EntityFrameworkCore;

namespace APBDTEST2.Models
{
    public class s21901Context : DbContext
    {
        public s21901Context()
        {

        }

        public s21901Context(DbContextOptions options) : base(options)
        {
             

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s21901;Integrated Security=True");
        }

        public DbSet<Plane> planes { get; set; }
        public DbSet<Flight> flights { get; set; }
        public DbSet<CityDict> cityDicts { get; set; }
        public DbSet<Passenger> passengers { get; set; }
        public DbSet<Flight_Passenger> flight_Passengers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Plane>(e =>
            {
                e.HasData(new Plane { IdPlane = 1, Name = "harsh", MaxSeats = 30 });
            });

            builder.Entity<CityDict>(e =>
            {
                e.HasData(new CityDict { IdCityDict = 1, City = "mumbai" });
            });

            builder.Entity<Flight_Passenger>(e =>
            {
                e.HasKey(x => new { x.IdFlight, x.IdPassenger });
                e.HasData(new Flight_Passenger
                {
                    IdFlight = 1,
                    IdPassenger = 1,
                });
            });

            builder.Entity<Passenger>(e =>
            {
                e.HasData(new Passenger
                {
                    IdPassenger = 1,
                    FirstName = "harsh",
                    LastName = "patel",
                    PassportNum = "124"
                });
            });

            builder.Entity<Flight>(e =>
            {
                e.HasKey(x => x.IdFlight);
                e.HasData(new Flight
                {
                    IdCityDict = 1,
                    IdPlane = 1,
                    IdFlight = 1,
                    Comments = "yo",
                    FlightDate = new DateTime(2020, 1, 1)
                });
            });
        }
    }
}
