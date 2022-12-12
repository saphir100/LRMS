using Application.Common.Models.BaseEntity;
using Application.Common.Models.LeaveType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.LeaveAllocation
{
    public class LeaveAllocationDto: BaseEntityDto
    {

        public int NumberOfDays { get; set; }

        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
