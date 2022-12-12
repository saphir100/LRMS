using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.LeaveRequests.Commands
{
    public class DeleteLeaveRequestCommand:IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _mapper=mapper;
            _leaveRequestRepository=leaveRequestRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);
            if (leaveRequest == null)
                throw new NotFoundException(nameof(leaveRequest), request.Id);
            await _leaveRequestRepository.Delete(leaveRequest);
            return Unit.Value;
        }
    }
}
