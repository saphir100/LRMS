﻿using Application.Common.Models.LeaveType;
using Application.TodoItems.LeaveTypes.Commands;
using Application.TodoItems.LeaveTypes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Autherize]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveTypeController(IMediator madiator)
        {
            _mediator  = madiator;

        }
        // GET: api/<LeaveTypeController>
        [HttpGet]
        [Autherize]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());
            return leaveTypes;
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id }) ;
            return leaveTypes;
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveTypeDto leaveType)
        {
            var command = new CreateLeaveTypeCommand { LeaveTypeDto= leaveType };
            var response=await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveTypeController>
        [HttpPut]
        public async Task<ActionResult> Put( [FromBody] LeaveTypeDto leaveType)
        {
            var command= new UpdateLeaveTypeCommand { LeaveTypeDto= leaveType };
            var response = await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command=new DeleteLeaveTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
