using Management.Application.Features.Commands.Buildings.Blocks.AddBlock;
using Management.Application.Features.Queries.Buildings.GetBlockList.GetAllBlock;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers.BuildingsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlocksController : ControllerBase
    {
        IMediator _mediator;

        public BlocksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllApartmentType()
        {
            var apartmentTypeList = await _mediator.Send(new GetBlockListQuery());
            return Ok(apartmentTypeList);
        }
        [HttpPost]
        public async Task<IActionResult> AddApartmnetType(AddBlockCommand addBlockCommand)
        {
            var apartmentTypeToAdd = await _mediator.Send(addBlockCommand);
            return Ok(apartmentTypeToAdd);
        }
    }
}
