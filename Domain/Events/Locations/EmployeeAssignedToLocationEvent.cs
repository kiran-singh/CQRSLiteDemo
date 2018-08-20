using System;

namespace Domain.Events.Locations
{
    public class EmployeeAssignedToLocationEvent : BaseEvent
    {
        public readonly int NewLocationId;
        public readonly int EmployeeID;

        public EmployeeAssignedToLocationEvent(Guid id, int newLocationId, int employeeID)
        {
            Id = id;
            NewLocationId = newLocationId;
            EmployeeID = employeeID;
        }
    }
}