using Management.Application.Features.Commands.Buildings.Blocks.AddBlock;
using Management.Application.Features.Queries.Buildings.GetBlockList.GetAllBlock;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers.BuildingsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BlocksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlocksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllApartmentType()
        {
            //all apartment type
            var apartmentTypeList = await _mediator.Send(new GetBlockListQuery());
            return Ok(apartmentTypeList);
        }
        [HttpPost]
        public async Task<IActionResult> AddApartmnetType(AddBlockCommand addBlockCommand)
        {
            //adding apartment type
            var apartmentTypeToAdd = await _mediator.Send(addBlockCommand);
            return Ok(apartmentTypeToAdd);
        }
    }
}
