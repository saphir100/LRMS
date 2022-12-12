using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.Models.LeaveRequest;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.LeaveRequests.Commands
{
    public class UpdateLeaveRequestCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDto LeaveRequestDto { get; set; }

        public ChangeLeaveRequestApprovedDto ChangeLeaveRequestApprovedDto { get; set; }
    }

    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _mapper= mapper;
            _leaveRequestRepository= leaveRequestRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (request.LeaveRequestDto !=null)
            {
                _mapper.Map(request.LeaveRequestDto, leaveRequest);
                await _leaveRequestRepository.Update(leaveRequest);

            }
            else if (request.ChangeLeaveRequestApprovedDto!=null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest,request.ChangeLeaveRequestApprovedDto.Approved);
            }

            return Unit.Value;
        }
    }
}
