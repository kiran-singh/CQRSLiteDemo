using System;

namespace Domain.Events.Locations
{
    public class EmployeeRemovedFromLocationEvent : BaseEvent
    {
        public readonly int OldLocationId;
        public readonly int EmployeeId;

        public EmployeeRemovedFromLocationEvent(Guid id, int oldLocationID, int employeeID)
        {
            Id = id;
            OldLocationId = oldLocationID;
            EmployeeId = employeeID;
        }
    }
}