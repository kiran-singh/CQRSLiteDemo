using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.Domain;
using Domain.Commands;
using Domain.WriteModel;

namespace Domain.CommandHandlers
{
    public class LocationCommandHandler : ICommandHandler<CreateLocationCommand>,
                                            ICommandHandler<AssignEmployeeToLocationCommand>,
                                            ICommandHandler<RemoveEmployeeFromLocationCommand>
    {
        private readonly ISession _session;

        public LocationCommandHandler(ISession session)
        {
            _session = session;
        }

        public async Task Handle(CreateLocationCommand command)
        {
            var location = new Location(command.Id, command.LocationId, command.StreetAddress, command.City,
                command.State, command.PostalCode);

            await _session.Add(location);

            await _session.Commit();
        }

        public async Task Handle(AssignEmployeeToLocationCommand command)
        {
            var location = await _session.Get<Location>(command.Id);
            location.AddEmployee(command.EmployeeId);
            await _session.Commit();
        }

        public async Task Handle(RemoveEmployeeFromLocationCommand command)
        {
            var location = await _session.Get<Location>(command.Id);
            location.RemoveEmployee(command.EmployeeId);
            await _session.Commit();
        }
    }
}