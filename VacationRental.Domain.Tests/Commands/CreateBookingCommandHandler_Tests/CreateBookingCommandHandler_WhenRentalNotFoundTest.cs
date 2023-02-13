using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using VacationRental.Domain.Commands.CreateBooking;
using VacationRental.Domain.Core.Entities;
using VacationRental.Domain.Core.Exceptions;

namespace VacationRental.Domain.Tests.Commands.CreateBookingCommandHandler_Tests
{
    public class CreateBookingCommandHandler_WhenRentalNotFoundTest : CreateBookingCommandHandler_BaseTest 
    {
        private CreateBookingCommand Command;

        [SetUp]
        public void Arrange()
        {
            var bookingEntity = Fixture
                .Build<Booking>()
                .Create();

            Command = new CreateBookingCommand(2, DateTime.Now, 3, 2);

            RentalRepositoryMock
                .Setup(repository => repository.Get(It.IsAny<int>()))
                .Returns(It.IsAny<Rental>());
        }

        public Func<Task> Act => async () => _ = await CreateBookingCommandHandler.Handle(Command, CancellationToken);

        [Test]
        public void Assert()
        {
            Act.Should().ThrowAsync<RentalNotFoundException>();

            RentalRepositoryMock
                .Verify(repository => repository.Get(It.IsAny<int>()), Times.Once());
        }
    }
}
