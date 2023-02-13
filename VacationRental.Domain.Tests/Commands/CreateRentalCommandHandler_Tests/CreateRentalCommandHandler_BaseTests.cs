using AutoFixture;
using Moq;
using NUnit.Framework;
using VacationRental.Domain.Commands.CreateRental;
using VacationRental.Domain.Core.Entities;
using VacationRental.Domain.Core.Repositories;

namespace VacationRental.Domain.Tests.Commands.CreateRentalCommandHandler_Tests
{
    public class CreateRentalCommandHandler_BaseTests
    {
        protected Mock<IRepository<Rental>> RentalRepositoryMock;
        protected CreateRentalCommandHandler CreateRentalCommandHandler;
        protected CancellationToken CancellationToken;
        protected Fixture Fixture;

        [SetUp]
        public void SetUp()
        {
            RentalRepositoryMock = new();
            CancellationToken = new();
            Fixture = new();

            CreateRentalCommandHandler = new CreateRentalCommandHandler(
                RentalRepositoryMock.Object);
        }
    }
}
