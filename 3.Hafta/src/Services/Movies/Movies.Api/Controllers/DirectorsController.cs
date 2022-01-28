using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Contract.Services;
using Movies.Domain.Entities;

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorService _direcotorService;
        public DirectorsController(IDirectorService direcotorService)
        {
            _direcotorService = direcotorService;
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Director>>> Add(Director director)
        {
            ///if the length of name of genre is bigger than zero add to database.
            if (director.FirstName.Length > 0)
            {
                var directorToAdd = await _direcotorService.Add(director);
                return Ok(directorToAdd);
            }
            return BadRequest();
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<Director>> Delete(int id)
        {
            ///to do the 'Delete Operation' with id, first reach the Entity with id.
            ///Then use that entity for Delete Operation
            var directorToDelete = await _direcotorService.GetById(id);
            return await _direcotorService.Delete(directorToDelete);


        }
        [HttpPut]
        public async Task<ActionResult<Director>> Update(Director director)
        {
            return await _direcotorService.Update(director);
        }
        [HttpGet]
        public async Task<IReadOnlyList<Director>> GetAll()
        {
            return await _direcotorService.GetAll();

        }
        [HttpGet]
        [Route("search")]
        public async Task<IReadOnlyList<Director>> GetByName(string name)
        {
            return await _direcotorService.GetByName(name);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Director>> GetById(int id)
        {
            return await _direcotorService.GetById(id);





        }

    }
}
