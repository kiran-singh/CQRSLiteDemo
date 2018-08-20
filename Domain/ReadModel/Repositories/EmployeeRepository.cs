using System.Collections.Generic;
using System.Linq;
using Domain.ReadModel.Repositories.Interfaces;
using MongoDB.Driver;
using StackExchange.Redis;

namespace Domain.ReadModel.Repositories
{
    public class EmployeeRepository : BaseRepository<EmployeeRM>, IEmployeeRepository
    {

        public EmployeeRepository(IMongoCollection<EmployeeRM> collection) : base(collection)
        {
        }
    }
}