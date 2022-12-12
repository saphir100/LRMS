using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class LeaveManagementDbContextFactor :
        IDesignTimeDbContextFactory<LeaveManagementDbContext>
    {
        //public LeaveManagementDbContext CreateDbContext(string[] args)
        //{




        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //        //.SetBasePath("../WebUI/")
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")

        //        .Build();
        //    var builder = new DbContextOptionsBuilder<LeaveManagementDbContext>();

        //    var connectionString = configuration.GetConnectionString("LeaveManagementConnectionString");
        //    builder.UseSqlServer(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
        //    return new LeaveManagementDbContext(builder.Options);

        //}

        public LeaveManagementDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LeaveManagementDbContext>();
            optionsBuilder.UseSqlServer(@"Server=.\;Database=LRMS;Trusted_Connection=True;TrustServerCertificate=True", opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));

            return new LeaveManagementDbContext(optionsBuilder.Options);
        }
    }
}
