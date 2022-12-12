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
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
            new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Vacation",
                CreatedBy = "09f5a295-7712-4a27-a929-edb6e41ebe05",
                LastModifiedBy= "09f5a295-7712-4a27-a929-edb6e41ebe05"
            },
            new LeaveType
            {
                Id = 2,
                DefaultDays = 12,
                Name = "Sick",
                CreatedBy = "09f5a295-7712-4a27-a929-edb6e41ebe05",
                LastModifiedBy = "09f5a295-7712-4a27-a929-edb6e41ebe05"

            });
        }
    }
}
