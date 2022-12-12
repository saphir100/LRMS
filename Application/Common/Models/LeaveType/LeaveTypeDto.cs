using Application.Common.Models.BaseEntity;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.LeaveType
{
    public class LeaveTypeDto: BaseEntityDto
    {

        public string Name { get; set; }
        public int DefaultDays { get; set; }

    }
}
