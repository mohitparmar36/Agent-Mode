using LogParking.Infrastructure.Entities;

namespace LogParking.Infrastructure.Contracts
{
    public interface IParkingRepository
    {
        Task<IEnumerable<Parking>> GetAllAsync();
        Task<Parking?> GetByIdAsync(int id);
        Task<Parking> AddAsync(Parking parking);
        Task<Parking?> UpdateAsync(Parking parking);
        Task<bool> DeleteAsync(int id);
    }
}
