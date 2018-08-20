using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.ReadModel.Repositories.Interfaces
{
    public interface ILocationRepository : IBaseRepository<LocationRM>
    {
        Task<IEnumerable<EmployeeRM>> EmployeesAt(int id);
        
        Task<bool> HasEmployee(int locationId, int employeeId);
    }
}