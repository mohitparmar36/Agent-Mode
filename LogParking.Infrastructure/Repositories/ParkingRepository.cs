using LogParking.Infrastructure.Contracts;
using LogParking.Infrastructure.Data;
using LogParking.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogParking.Infrastructure.Repositories
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly ParkingDbContext _context;
        public ParkingRepository(ParkingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parking>> GetAllAsync()
            => await _context.Parkings.ToListAsync();

        public async Task<Parking?> GetByIdAsync(int id)
            => await _context.Parkings.FindAsync(id);

        public async Task<Parking> AddAsync(Parking parking)
        {
            _context.Parkings.Add(parking);
            await _context.SaveChangesAsync();
            return parking;
        }

        public async Task<Parking?> UpdateAsync(Parking parking)
        {
            var existing = await _context.Parkings.FindAsync(parking.Id);
            if (existing == null) return null;
            existing.Location = parking.Location;
            existing.VehicleNumber = parking.VehicleNumber;
            existing.ParkedAt = parking.ParkedAt;
            existing.ExitedAt = parking.ExitedAt;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var parking = await _context.Parkings.FindAsync(id);
            if (parking == null) return false;
            _context.Parkings.Remove(parking);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
