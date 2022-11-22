using GameStore.Application.Interfaces;
using GameStore.Application.Models.Genres.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        public GenresController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        private readonly IGenreService genreService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await genreService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await genreService.GetAllAsync();

            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddGenreRequest request)
        {
            var result = await genreService.AddAsync(request);

            return CreatedAtAction(nameof(GetById), new { result.Id }, result);
        }
    }
}
