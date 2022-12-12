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
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                   
                    RoleId = "c9ae6a12-02c9-429c-b12d-3a8f4eb8654c",
                    UserId= "35a46160-3867-41a2-8930-f2343671f939"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "96862c62-cc3d-4af6-873a-aff23efb39af",
                    UserId = "55b45bf0-5381-460f-ac7b-a528bdacc1f3"
                });
            
        }
    }
}
