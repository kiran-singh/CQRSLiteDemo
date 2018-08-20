using System;

namespace Domain.Commands
{
    public class AssignEmployeeToLocationCommand : BaseCommand
    {
        public int EmployeeId { get; }
        public int LocationId { get; }

        public AssignEmployeeToLocationCommand(Guid id, int locationId, int employeeId)
        {
            Id = id;
            EmployeeId = employeeId;
            LocationId = locationId;
        }
    }
}