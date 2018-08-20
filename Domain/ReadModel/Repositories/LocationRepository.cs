using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ReadModel.Repositories.Interfaces;
using MongoDB.Driver;
using StackExchange.Redis;

namespace Domain.ReadModel.Repositories
{
    public class LocationRepository : BaseRepository<LocationRM>, ILocationRepository
    {
        private readonly IEmployeeRepository _employeeRepository;

        public LocationRepository(IMongoCollection<LocationRM> collection, IEmployeeRepository employeeRepository) : base(collection)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeRM>> EmployeesAt(int id)
        {
            var employeeIds = await Collection.Find(x => x.Id == id).Project(x => x.Employees).FirstOrDefaultAsync();

            return await _employeeRepository.GetMany(employeeIds.ToArray());
        }

        public async Task<bool> HasEmployee(int locationId, int employeeId)
        {
            var employeeIds = await Collection.Find(x => x.Id == locationId).Project(x => x.Employees).FirstOrDefaultAsync();
            
            return employeeIds.Contains(employeeId);
        }
    }
}