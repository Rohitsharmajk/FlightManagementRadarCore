using Microsoft.EntityFrameworkCore;
using flightmanagementradar.models;

namespace FlightManagementRadar.Models
{
    public class FlightManagementContext : DbContext
    {
        public FlightManagementContext(DbContextOptions<FlightManagementContext> options) :base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Flight_Data> Flight_Datas { get; set; }
        public DbSet<CheckIn_Detail> CheckIn_Details { get; set; }
    }
}
