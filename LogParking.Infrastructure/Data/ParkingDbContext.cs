using LogParking.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogParking.Infrastructure.Data
{
    public class ParkingDbContext : DbContext
    {
        public ParkingDbContext(DbContextOptions<ParkingDbContext> options) : base(options) { }
        public DbSet<Parking> Parkings { get; set; }
    }
}
