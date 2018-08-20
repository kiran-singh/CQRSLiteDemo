using System.Threading.Tasks;
using AutoMapper;
using Domain.EventHandlers;
using Domain.Events.Employees;
using Domain.ReadModel;
using Domain.ReadModel.Repositories.Interfaces;
using Moq;
using NUnit.Framework;
using Xunit;

namespace Domain.Tests.EventHandlers
{
    public class EmployeeEventHandlerTests
    {
        private EmployeeEventHandler _eventhandler;
        private Mock<IMapper> _mapper;
        private Mock<IEmployeeRepository> _employeeRepo;

        public EmployeeEventHandlerTests()
        {
            _mapper = new Mock<IMapper>();
            _employeeRepo = new Mock<IEmployeeRepository>();
            _eventhandler = new EmployeeEventHandler(_mapper.Object, _employeeRepo.Object);
        }
        
        [Fact]
        public async Task Handle_AddEvent_EmployeeMappedAndSaved()
        {
            // Arrange
            var employeeCreatedEvent = new Mock<EmployeeCreatedEvent>().Object;
            var employeeRm = new Mock<EmployeeRM>().Object;
            _mapper.Setup(x => x.Map<EmployeeCreatedEvent, EmployeeRM>(employeeCreatedEvent))
                .Returns(employeeRm);

            // Act
            await _eventhandler.Handle(employeeCreatedEvent);
            
            // Assert
            _mapper.Verify(x => x.Map<EmployeeCreatedEvent, EmployeeRM>(employeeCreatedEvent));
            _employeeRepo.Verify(x => x.Save(employeeRm));
        }
    }
}