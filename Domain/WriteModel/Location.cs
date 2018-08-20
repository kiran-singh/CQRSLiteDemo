using System;
using System.Collections.Generic;
using CQRSlite.Domain;
using Domain.Events.Locations;

namespace Domain.WriteModel
{
    public class Location : AggregateRoot
    {
        private int _locationId;
        private string _streetAddress;
        private string _city;
        private string _state;
        private string _postalCode;
        private List<int> _employees;

        private Location() { }

        public Location(Guid id, int locationId, string streetAddress, string city, string state, string postalCode)
        {
            Id = id;
            _locationId = locationId;
            _streetAddress = streetAddress;
            _city = city;
            _state = state;
            _postalCode = postalCode;
            _employees = new List<int>();

            ApplyChange(new LocationCreatedEvent(id, locationId, streetAddress, city, state, postalCode));
        }

        public void AddEmployee(int employeeId)
        {
            _employees.Add(employeeId);

            ApplyChange(new EmployeeAssignedToLocationEvent(Id, _locationId, employeeId));
        }

        public void RemoveEmployee(int employeeId)
        {
            _employees.Remove(employeeId);

            ApplyChange(new EmployeeRemovedFromLocationEvent(Id, _locationId, employeeId));
        }
    }
}