﻿using Application.Common.Interfaces;
using Application.Common.Models.LeaveType;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.LeaveTypes.Queries
{
    public class GetLeaveTypeDetailRequest:IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
    }

    public class GetLeaveTypeDetailHandler : IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDto>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public GetLeaveTypeDetailHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType=await _leaveTypeRepository.Get(request.Id);
            return _mapper.Map<LeaveTypeDto>(leaveType);
        }
    }

}
