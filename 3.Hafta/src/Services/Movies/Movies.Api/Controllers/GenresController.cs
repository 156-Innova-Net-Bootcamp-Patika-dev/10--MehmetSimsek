using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Contract.Services;
using Movies.Domain.Entities;

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService; 
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Genre>>> Add(Genre genre)
        {
            ///if the length of name of genre is bigger than zero add to database.
            if (genre.Name.Length>0)
            {
                var genreToAdd = await _genreService.Add(genre);
                return Ok(genreToAdd);
            }
           return BadRequest();
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<Genre>> Delete(int id)
        {
            ///to do the 'Delete Operation' with id, first reach the Entity with id.
            ///Then use that entity for Delete Operation
           var genreToDelete = await _genreService.GetById(id);
            return await _genreService.Delete(genreToDelete);
            
            
        }
        [HttpPut]
        public async Task<ActionResult<Genre>> Update(Genre genre)
        {
            return await _genreService.Update(genre);
        }
        [HttpGet]
        public async Task<IReadOnlyList<Genre>> GetAll()
        {
            return await _genreService.GetAll();
        }
        [HttpGet]
        [Route("search")]
        public async Task<IReadOnlyList<Genre>> GetByName(string name)
        {
            return await _genreService.GetByName(name);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetById(int id)
        {
            return await _genreService.GetById(id);   
        }
    }
}
