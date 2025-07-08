using LogParking.AppService.Contracts;
using LogParking.AppService.DTOs;
using LogParking.Utility;
using Microsoft.AspNetCore.Mvc;

namespace LogParking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _service;
        public ParkingController(IParkingService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _service.GetAllAsync();
                return Ok(GenericResponse<IEnumerable<ParkingDto>>.Ok(data));
            }
            catch (Exception ex)
            {
                return StatusCode(500, GenericResponse<IEnumerable<ParkingDto>>.Fail(ex.Message));
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null)
                    return NotFound(GenericResponse<ParkingDto>.Fail("Parking not found"));
                return Ok(GenericResponse<ParkingDto>.Ok(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, GenericResponse<ParkingDto>.Fail(ex.Message));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(ParkingDto dto)
        {
            try
            {
                var created = await _service.AddAsync(dto);
                return CreatedAtAction(nameof(Get), new { id = created.Id }, GenericResponse<ParkingDto>.Ok(created));
            }
            catch (Exception ex)
            {
                return StatusCode(500, GenericResponse<ParkingDto>.Fail(ex.Message));
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ParkingDto dto)
        {
            if (id != dto.Id)
                return BadRequest(GenericResponse<ParkingDto>.Fail("Id mismatch"));
            try
            {
                var updated = await _service.UpdateAsync(dto);
                if (updated == null)
                    return NotFound(GenericResponse<ParkingDto>.Fail("Parking not found"));
                return Ok(GenericResponse<ParkingDto>.Ok(updated));
            }
            catch (Exception ex)
            {
                return StatusCode(500, GenericResponse<ParkingDto>.Fail(ex.Message));
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _service.DeleteAsync(id);
                if (!deleted)
                    return NotFound(GenericResponse<bool>.Fail("Parking not found"));
                return Ok(GenericResponse<bool>.Ok(true));
            }
            catch (Exception ex)
            {
                return StatusCode(500, GenericResponse<bool>.Fail(ex.Message));
            }
        }
    }
}
