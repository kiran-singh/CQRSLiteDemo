using System.Threading.Tasks;
using AutoMapper;
using CQRSlite.Events;
using Domain.Events.Employees;
using Domain.ReadModel;
using Domain.ReadModel.Repositories.Interfaces;

namespace Domain.EventHandlers
{
    public class EmployeeEventHandler : IEventHandler<EmployeeCreatedEvent>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeEventHandler(IMapper mapper, IEmployeeRepository employeeRepo)
        {
            _mapper = mapper;
            _employeeRepo = employeeRepo;
        }

        public async Task Handle(EmployeeCreatedEvent message)
        {
            var employee = _mapper.Map<EmployeeCreatedEvent, EmployeeRM>(message);
            
            await _employeeRepo.Save(employee);
            
            // TODO: error if save returns false
        }
    }
}