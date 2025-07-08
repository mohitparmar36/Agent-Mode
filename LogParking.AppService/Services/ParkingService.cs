using LogParking.AppService.Contracts;
using LogParking.AppService.DTOs;
using LogParking.Infrastructure.Contracts;
using LogParking.Infrastructure.Entities;

namespace LogParking.AppService.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository _repository;
        public ParkingService(IParkingRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ParkingDto>> GetAllAsync()
        {
            var parkings = await _repository.GetAllAsync();
            return parkings.Select(ToDto);
        }

        public async Task<ParkingDto?> GetByIdAsync(int id)
        {
            var parking = await _repository.GetByIdAsync(id);
            return parking == null ? null : ToDto(parking);
        }

        public async Task<ParkingDto> AddAsync(ParkingDto dto)
        {
            var entity = ToEntity(dto);
            var added = await _repository.AddAsync(entity);
            return ToDto(added);
        }

        public async Task<ParkingDto?> UpdateAsync(ParkingDto dto)
        {
            var entity = ToEntity(dto);
            var updated = await _repository.UpdateAsync(entity);
            return updated == null ? null : ToDto(updated);
        }

        public async Task<bool> DeleteAsync(int id)
            => await _repository.DeleteAsync(id);

        private static ParkingDto ToDto(Parking p) => new()
        {
            Id = p.Id,
            Location = p.Location,
            VehicleNumber = p.VehicleNumber,
            ParkedAt = p.ParkedAt,
            ExitedAt = p.ExitedAt
        };

        private static Parking ToEntity(ParkingDto dto) => new()
        {
            Id = dto.Id,
            Location = dto.Location,
            VehicleNumber = dto.VehicleNumber,
            ParkedAt = dto.ParkedAt,
            ExitedAt = dto.ExitedAt
        };
    }
}
