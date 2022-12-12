using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration.Entities
{
    public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {
            DateTime aDate = DateTime.Now;
            builder.HasData(
            new LeaveRequest
            {
                Id = 1,
                //LeaveType = new LeaveType { Id = 1, Name = "Sick" },
                LastModifiedBy = "09f5a295-7712-4a27-a929-edb6e41ebe05",
                CreatedBy = "09f5a295-7712-4a27-a929-edb6e41ebe05",
                Approved = false,
                Cancelled = false,
                StartDate = Convert.ToDateTime("05/05/2022"),
                EndDate = Convert.ToDateTime("10/05/2022"),
                DateActioned = Convert.ToDateTime("05/05/2022"),
                RequestComments="busy",
                LeaveTypeId=2
                

            },
            new LeaveRequest
            {
                Id = 2,
                //LeaveType = new LeaveType { Id = 1, Name = "Sick" },
                LastModifiedBy = "09f5a295-7712-4a27-a929-edb6e41ebe05",
                CreatedBy = "09f5a295-7712-4a27-a929-edb6e41ebe05",
                Approved = false,
                Cancelled = false,
                StartDate = Convert.ToDateTime("05/08/2022"),
                EndDate = Convert.ToDateTime("10/08/2022"),
                DateActioned = Convert.ToDateTime("05/08/2022"),
                RequestComments = "busy",
                LeaveTypeId = 2

            });
        }
    }
}
