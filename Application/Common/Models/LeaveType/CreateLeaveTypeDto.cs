using Application.Common.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.LeaveType
{
    public class CreateLeaveTypeDto:BaseEntityDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
