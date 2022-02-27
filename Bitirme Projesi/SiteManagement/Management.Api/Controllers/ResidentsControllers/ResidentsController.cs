using Management.Application.Features.Commands.Residents.AddResident;
using Management.Application.Features.Commands.Residents.DeleteResident;
using Management.Application.Features.Commands.Residents.UpdateResident;
using Management.Application.Features.Queries.Residents.GetResidentsList.GetAllResident;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers.ResidentsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class ResidentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResidentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllResident()
        {
            // listing all residents
            return Ok(await _mediator.Send(new GetResidentListQuery()));
        }
        [HttpPost]
        public async Task<ActionResult<int>> AddResident(AddResidentCommand addResidentCommand)
        {
            //adding residents
            var residentToAdd = await _mediator.Send(addResidentCommand);
            return Ok(residentToAdd);
        }
        [HttpDelete("{id}", Name = "DeleteResident")]
        public async Task<ActionResult> DeleteResident(int id)
        {
            // to delete a resident
            var deleteResidentCommand = new DeleteResidentCommand();
            deleteResidentCommand.Id = id;
            await _mediator.Send(deleteResidentCommand);
            return NoContent();

        }
        [HttpPut(Name = "UpdateResident")]

        public async Task<IActionResult> UpdateResident(UpdateResidentCommand updateResidentCommand)
        {
            //To update resident
            var updatedResidant = await _mediator.Send(updateResidentCommand);
            return Ok(updatedResidant);

        }
    }
}
