using Microsoft.AspNetCore.Mvc;
using Papara_.NET_Bootcamp.GenreOperations.Commands.CreateGenre;
using Papara_.NET_Bootcamp.GenreOperations.Commands.DeleteGenre;
using Papara_.NET_Bootcamp.GenreOperations.Commands.UpdateGenre;
using Papara_.NET_Bootcamp.GenreOperations.Queries.GetGenreDetail;
using Papara_.NET_Bootcamp.GenreOperations.Queries.GetGenres;
using Papara_.NET_Bootcamp.Services;

[ApiController]
[Route("api/[controller]")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGenre([FromBody] CreateGenreCommand command)
    {
        var result = await _genreService.CreateGenreAsync(command);
        return CreatedAtAction(nameof(GetGenreById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGenre(int id, [FromBody] UpdateGenreCommand command)
    {
        command.Id = id;
        await _genreService.UpdateGenreAsync(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGenre(int id)
    {
        await _genreService.DeleteGenreAsync(new DeleteGenreCommand { Id = id });
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGenreById(int id)
    {
        var genre = await _genreService.GetGenreDetailAsync(new GetGenreDetailQuery { Id = id });
        return Ok(genre);
    }

    [HttpGet]
    public async Task<IActionResult> GetGenres()
    {
        var genres = await _genreService.GetGenresAsync(new GetGenresQuery());
        return Ok(genres);
    }
}
