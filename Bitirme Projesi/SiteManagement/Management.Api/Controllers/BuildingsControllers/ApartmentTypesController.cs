using Management.Application.Features.Commands.Buildings.ApartmentTypes.AddApartmentType;
using Management.Application.Features.Queries.Buildings.GetApartmentTypeList.GetAllApartmentType;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers.BuildingsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ApartmentTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApartmentTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllApartmentType()
        {
            //all apartment type
            var apartmentTypeList = await _mediator.Send(new GetApartmentTypeListQuery());
            return Ok(apartmentTypeList);
        }
        [HttpPost]
        public async Task<IActionResult> AddApartmnetType(AddApartmentTypeCommand addApartmentTypeCommand)
        {
            //adding apartment type
            var apartmentTypeToAdd = await _mediator.Send(addApartmentTypeCommand);
            return Ok(apartmentTypeToAdd);
        }
    }
}
