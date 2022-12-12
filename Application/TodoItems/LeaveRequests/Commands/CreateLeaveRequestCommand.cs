using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.Models.Email;
using Application.Common.Models.LeaveRequest;
using Application.Common.Response;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.LeaveRequests.Commands
{
    public class CreateLeaveRequestCommand:IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto LeaveRequestDto { get; set; }
    }

    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IEmailSender _emailSender;
        public CreateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository, 
            IMapper mapper,
            IEmailSender emailSender
            )
        {
            _mapper = mapper;
            _leaveRequestRepository = leaveRequestRepository;
            _emailSender = emailSender;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var leaveRequest=_mapper.Map<LeaveRequest>(request.LeaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
            response.Success= true;
            response.Message = "Creation Successful";
            response.Id= leaveRequest.Id;

            var email = new Email
            {
                To = "example@org.com",
                Body = $"Your Leave Request For {request.LeaveRequestDto.StartDate} to {request.LeaveRequestDto.EndDate} has been submitted successfully",
                Subject = "Leave Request Submitted"
            };
            try
            {
                await _emailSender.SendEmail(email);
            }catch(Exception ex)
            {
                //Log
            }
            return response;
        }
    }
}
