using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.Domain;
using Domain.Commands;
using Domain.WriteModel;

namespace Domain.CommandHandlers
{
    public class EmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand>
    {
        private readonly ISession _session;

        public EmployeeCommandHandler(ISession session)
        {
            _session = session;
        }

        public async Task Handle(CreateEmployeeCommand command)
        {
            var employee = new Employee(command.Id, command.EmployeeId, command.FirstName, command.LastName,
                command.DateOfBirth, command.JobTitle);

            await _session.Add(employee);
            await _session.Commit();
        }
    }
}