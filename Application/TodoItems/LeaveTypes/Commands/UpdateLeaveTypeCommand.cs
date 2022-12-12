
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.Models.LeaveType;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.LeaveTypes.Commands
{
    public class UpdateLeaveTypeCommand:IRequest<Unit>
    {
        public LeaveTypeDto LeaveTypeDto { get; set; }  
    }

    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _mapper= mapper;
            _leaveTypeRepository= leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType =await _leaveTypeRepository.Get(request.LeaveTypeDto.Id);
            _mapper.Map(request.LeaveTypeDto, leaveType);
            await _leaveTypeRepository.Update(leaveType);
            return Unit.Value;
        }
    }
}
