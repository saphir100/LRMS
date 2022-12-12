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
    public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
    {
        public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
        {
            builder.HasData(
            new LeaveAllocation
            {
                Id=1,
                CreatedBy= "09f5a295-7712-4a27-a929-edb6e41ebe05",
                LastModifiedBy= "09f5a295-7712-4a27-a929-edb6e41ebe05",
                NumberOfDays=3,
                LeaveTypeId=2,
                Period=3

            });
        }
    }
}
