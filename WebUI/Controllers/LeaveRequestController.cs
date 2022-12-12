using Application.Common.Models.LeaveRequest;
using Application.TodoItems.LeaveRequests.Commands;
using Application.TodoItems.LeaveRequests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveRequestController(IMediator madiator)
        {
            _mediator = madiator;

        }
        // GET: api/<LeaveRequestController>
        [HttpGet]
        public async Task<List<LeaveRequestListDto>> Get()
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestListRequest());
            return leaveRequests;
        }

        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        public async Task<LeaveRequestDto> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailRequest { Id = id });
            return leaveRequest;
        }

        // POST api/<LeaveRequestController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto createLeaveRequestDto)
        {
            var command = new CreateLeaveRequestCommand { LeaveRequestDto=createLeaveRequestDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto leaveRequestDto)
        {
            var command = new UpdateLeaveRequestCommand {Id=id, LeaveRequestDto=leaveRequestDto };
            var response = await _mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> ChangeApproval([FromBody] ChangeLeaveRequestApprovedDto changeLeaveRequestApproval)
        {
            var command = new UpdateLeaveRequestCommand { ChangeLeaveRequestApprovedDto = changeLeaveRequestApproval };
            var response = await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveRequestController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
