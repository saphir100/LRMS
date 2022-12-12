using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.LeaveTypes.Commands
{
    public class DeleteLeaveTypeCommand:IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository=   leaveTypeRepository;
            _mapper= mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);
            if(leaveType == null)
                throw new NotFoundException(nameof(leaveType),request.Id);
            await _leaveTypeRepository.Delete(leaveType);
            return Unit.Value;

        }
    }
}
