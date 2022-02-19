using Management.Application.Features.Commands.Buildings.Apartments.AddApartment;
using Management.Application.Features.Commands.Buildings.Apartments.DeleteApartment;
using Management.Application.Features.Commands.Buildings.Apartments.UpdateApartment;
using Management.Application.Features.Queries.Buildings.GetApartmentList.GetAllApartment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers.BuildingsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        IMediator _mediator;

        public ApartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllApartment()
        {
            var apartmentList = await _mediator.Send(new GetApartmentListQuery());
            return Ok(apartmentList);
        }
        [HttpPost]
        public async Task<IActionResult> AddApartments(AddApartmentCommand addApartmentCommand)
        {
            var apartmentToAdd = await _mediator.Send(addApartmentCommand);
            return Ok(apartmentToAdd);


        }
        [HttpDelete("{id}", Name = "DeleteApartment")]
        public async Task<IActionResult> DeleteApartment(int id)
        {
            var apartmentToDelete = new DeleteApartmentCommand() { Id = id };
            await _mediator.Send(id);
            return NoContent();
        }
        [HttpPut(Name = "UpdateApartment")]
        public async Task<IActionResult> UpdateApartment(UpdateApartmentCommand updateApartmentCommand)
        {
            await _mediator.Send(updateApartmentCommand);
            return NoContent();

        }
    }
}
