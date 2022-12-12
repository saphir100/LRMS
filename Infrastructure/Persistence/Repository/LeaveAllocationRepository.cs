using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class LeaveAllocationRepository : GenericRepository<LeaveRequest>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext dbContext):base(dbContext)
        {
            _dbContext= dbContext;
        }

        public Task<LeaveAllocation> Add(LeaveAllocation entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(LeaveAllocation entity)
        {
            throw new NotImplementedException();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _dbContext.LeaveAllocation
                 .Include(q => q.LeaveType)
                 .FirstOrDefaultAsync(q => q.Id == id);
            return leaveAllocation;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var leaveAllocation = await _dbContext.LeaveAllocation
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveAllocation;
        }

        public Task Update(LeaveAllocation entity)
        {
            throw new NotImplementedException();
        }

        Task<LeaveAllocation> IGenericRepository<LeaveAllocation>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<LeaveAllocation>> IGenericRepository<LeaveAllocation>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
