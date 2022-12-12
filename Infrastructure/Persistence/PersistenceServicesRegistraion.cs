using Application.Common.Interfaces;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Persistence
{
    public static class PersistenceServicesRegistraion
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<LeaveManagementDbContext>(option =>
                option.UseSqlServer("Server=.\\;Database=LRMS;Trusted_Connection=True;TrustServerCertificate=True"
                    /*configuration.GetConnectionString("LeaveManagementConnectionString")*/));

            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>) );

            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }
    }

}
