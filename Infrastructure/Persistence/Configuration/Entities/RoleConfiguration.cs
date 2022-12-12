
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "96862c62-cc3d-4af6-873a-aff23efb39af",
                    Name = "Employee",
                    NormalizedName ="EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "c9ae6a12-02c9-429c-b12d-3a8f4eb8654c",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"

                });
        }
    }
}
