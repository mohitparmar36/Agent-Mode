using LogParking.AppService.DTOs;

namespace LogParking.AppService.Contracts
{
    public interface IParkingService
    {
        Task<IEnumerable<ParkingDto>> GetAllAsync();
        Task<ParkingDto?> GetByIdAsync(int id);
        Task<ParkingDto> AddAsync(ParkingDto parking);
        Task<ParkingDto?> UpdateAsync(ParkingDto parking);
        Task<bool> DeleteAsync(int id);
    }
}
