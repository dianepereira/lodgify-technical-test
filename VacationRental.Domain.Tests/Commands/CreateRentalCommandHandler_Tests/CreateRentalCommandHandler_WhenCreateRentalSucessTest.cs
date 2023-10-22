using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using VacationRental.Domain.Commands.CreateRental;
using VacationRental.Domain.Core.Entities;

namespace VacationRental.Domain.Tests.Commands.CreateRentalCommandHandler_Tests
{
    public class CreateRentalCommandHandler_WhenCreateRentalSucessTest : CreateRentalCommandHandler_BaseTests
    {
        private CreateRentalCommand Command;

        [SetUp]
        public void Arrange()
        {

            var entity = Fixture
                .Build<Rental>()
                .Create();

            Command = Fixture
                   .Build<CreateRentalCommand>()
                   .Create();

            RentalRepositoryMock
                .Setup(repository => repository.Add(It.IsAny<Rental>()))
                .Returns(entity);
        }

        public Func<Task> Act => async () => _ = await CreateRentalCommandHandler.Handle(Command, CancellationToken);

        [Test]
        public void Assert()
        {
            Act.Should().NotThrowAsync();

            RentalRepositoryMock
                .Verify(repository => repository.Add(It.IsAny<Rental>()), Times.Once);
        }
    }
}
