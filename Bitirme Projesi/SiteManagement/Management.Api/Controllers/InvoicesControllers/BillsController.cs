using Management.Application.Features.Commands.Invoices.Bills.AddBill;
using Management.Application.Features.Queries.Invoices.GetBill.GetBillByApartmentId;
using Management.Application.Features.Queries.Invoices.GetBill.GetBillByBlockNameAndApartmentNumber;
using Management.Application.Features.Queries.Invoices.GetBill.GetBillByMonthId;
using Management.Application.Features.Queries.Invoices.GetBillList.GetAllBill;
using Management.Application.Features.Queries.Invoices.GetBorrowList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers.InvoicesControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class BillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BillsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllBill()
        {
            //getting all bills
            var billList = await _mediator.Send(new GetBillListQuery());
            return Ok(billList);
        }
        [HttpGet("{apartmentId}/{monthId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBorrowList(int monthId,int apartmentId)
        {
            //getting total borrow list for dedicating month according to apartmentId
            var borrowAmount = await _mediator.Send(new GetBorrowListQuery(monthId, apartmentId));
            return Ok(borrowAmount);
        }
        [HttpGet("/by/{apartmentId}")]
        public async Task<IActionResult> GetBillByApartmentId(int apartmentId)
        {
            // getting bill using apatment Id
            var bills = await _mediator.Send(new GetBillByApartmentIdQuery(apartmentId));
            return Ok(bills);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBill(AddBillCommand billCommand)
        {
            //adding Bill
            var apartmentTypeToAdd = await _mediator.Send(billCommand);
            return Ok(apartmentTypeToAdd);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBillByMonthId(int monthId)
        {
            //Showing bills according to Month which is indicated
            var bill = await _mediator.Send(new GetBillByMonthIdQuery());
            return Ok(bill);
        }
        [HttpGet("/by/{blockName}/and/{apartmentNumber}")]
        public async Task<IActionResult> GetBillByBlockNameAndApartmentNumber(string blockName,int apartmentNumber)
        {
            // getting bills according to apartment number and it's block
            var bills = await _mediator.Send(new GetBillByBlockNameAndApartmentNumberQuery(blockName, apartmentNumber));
            return Ok(bills);
        }
    }
}
