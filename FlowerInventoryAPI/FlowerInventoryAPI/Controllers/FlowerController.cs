using FlowerInventoryAPI.Entities;
using FlowerInventoryAPI.Services.FlowerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlowerInventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        private readonly IFlowerService _service;

        public FlowerController(IFlowerService service)
        {
            _service = service;
        }

        [HttpGet("GetAllFlowers")]
        public async Task<ActionResult<List<Flower>>> GetAllFlowers()
        {
            var result = await _service.GetAllFlowers();
            return Ok(result);
        }

        [HttpGet("GetFlowerByFlowerId")]
        public async Task<ActionResult<Flower>> GetFlowerByFlowerId(int flowerId)
        {
            var result = await _service.GetFlowerByFlowerId(flowerId);
            return Ok(result);
        }

        [HttpPost("CreateFlower")]
        public async Task<ActionResult<Flower>> CreateFlower([FromBody] Flower flowerRequest)
        {
            var result = await _service.CreateFlower(flowerRequest);
            return Ok(result);
        }

        [HttpPut("UpdateFlower")]
        public async Task<ActionResult<Flower>> UpdateFlower([FromBody] Flower flowerRequest)
        {
            var result = await _service.UpdateFlower(flowerRequest);
            return Ok(result);
        }

        [HttpDelete("DeleteFlower")]
        public async Task<ActionResult<BaseCommandResponse>> DeleteFlower([FromBody] Flower flowerRequest)
        {
            var result = await _service.DeleteFlower(flowerRequest);
            return Ok(result);
        }
    }
}
