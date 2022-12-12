using Application.Common.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.LeaveRequest
{
    public class ChangeLeaveRequestApprovedDto:BaseEntityDto
    {
        public bool? Approved { get; set; }

    }
}
