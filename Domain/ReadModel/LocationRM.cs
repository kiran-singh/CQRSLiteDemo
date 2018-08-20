using System;
using System.Collections.Generic;
using Domain.ReadModel.Repositories;
using MongoDB.Driver;

namespace Domain.ReadModel
{
    public class LocationRM : IId
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

        public string StreetAddress { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string PostalCode { get; set; }
        
        public List<int> Employees { get; set; }

        public LocationRM()
        {
            Employees = new List<int>();
        }
    }
}