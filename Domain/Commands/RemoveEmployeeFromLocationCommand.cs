using System;

namespace Domain.Commands
{
    public class RemoveEmployeeFromLocationCommand : AssignEmployeeToLocationCommand
    {
        public RemoveEmployeeFromLocationCommand(Guid id, int locationId, int employeeId) : base(id, locationId, employeeId)
        {
        }
    }
}