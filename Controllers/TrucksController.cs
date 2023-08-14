using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrucksAPI.Models.Trucks;
using TrucksAPI.Services;

namespace TrucksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly ITruckService _service;

        public TrucksController(ITruckService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trucks = await _service.GetAll();

            return Ok(trucks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var truck = await _service.GetById(id);

            return Ok(truck);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateRequest model)
        {
            await _service.Add(model);

            return Ok(new { message = "Truck created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, UpdateRequest model)
        {
            await _service.Update(id, model);

            return Ok(new { message = "Truck updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeleteById(id);

            return Ok(new { message = "Truck deleted" });
        }
    }
}
