using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Contract.Repository;
using Movies.Application.Contract.Services;
using Movies.Domain.Entities;
using Movies.Domain.Entities.DTOs;
using Movies.Domain.Entities.IntermediateTables;
using System.Web.Http.Description;

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Movie>>> Add(Movie movie)
        {
            ///if the length of name of genre is bigger than zero add to database.
            if (movie.Title.Length > 0)
            {
                var movieToAdd = await _movieService.Add(movie);
                return Ok(movieToAdd);
            }
            return BadRequest();
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<Movie>> Delete(int id)
        {
            ///to do the 'Delete Operation' with id, first reach the Entity with id.
            ///Then use that entity for Delete Operation
            var movieToDelete = await _movieService.GetById(id);
            return await _movieService.Delete(movieToDelete);


        }
        [HttpPut]
        public async Task<ActionResult<Movie>> Update(Movie movie)
        {
            return await _movieService.Update(movie);
        }
        [HttpGet]
        [ResponseType(typeof(MovieDetailDto))]
        public async Task<IReadOnlyList<Movie>> GetAll()
        {
            return await _movieService.GetAll();
            
        }
        [HttpGet]
        [Route("search")]
        public async Task<IReadOnlyList<Movie>> GetByName(string name)
        {
            return await _movieService.GetByName(name);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetById(int id)
        {
             return await _movieService.GetById(id);


            

            
        }

     

    }
}
