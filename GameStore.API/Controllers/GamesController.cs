using GameStore.Application.Interfaces;
using GameStore.Application.Models.Games.Requests;
using GameStore.Common.Filtering.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        public GamesController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        private readonly IGameService gameService;

        [HttpGet]
        public async Task<IActionResult> GetAllWithFilter([FromQuery] GameFilter filter)
        {
            var result = await gameService.GetForSaleAsync(filter);

            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SetGameDetailsRequest request)
        {
            var result = await gameService.AddAsync(request);

            return CreatedAtAction(nameof(request), result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await gameService.GetByIdAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await gameService.DeleteByIdAsync(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] SetGameDetailsRequest request)
        {
            await gameService.UpdateAsync(id, request);

            return Ok();
        }
    }
}
