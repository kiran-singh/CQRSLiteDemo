using System;
using Domain.ReadModel.Repositories;
using MongoDB.Driver;

namespace Domain.ReadModel
{
    public class EmployeeRM : IId
    {
        public Guid AggregateId { get; set; }

        public int Id { get; set; }
        
        public FilterDefinition<T> FilterDefinition<T>()
        {
            throw new NotImplementedException();
        }

        public UpdateDefinition<T> UpdateDefinition<T>()
        {
            throw new NotImplementedException();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string JobTitle { get; set; }

        public int LocationId { get; set; }
    }
}