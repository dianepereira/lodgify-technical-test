using AutoFixture;
using Moq;
using NUnit.Framework;
using VacationRental.Domain.Core.Entities;
using VacationRental.Domain.Core.Repositories;
using VacationRental.Domain.Queries.GetRental;

namespace VacationRental.Domain.Tests.Queries.GetCalendarQueryHandler_Tests
{
    public class GetRentalQueryHandler_BaseTests
    {

        protected Mock<IRepository<Rental>> RentalRepositoryMock;
        protected GetRentalQueryHandler GetRentalQueryHandler;
        protected CancellationToken CancellationToken;
        protected Fixture Fixture;

        [SetUp]
        public void SetUp()
        {
            RentalRepositoryMock = new();
            CancellationToken = new();
            Fixture = new();

            GetRentalQueryHandler = new GetRentalQueryHandler(
                RentalRepositoryMock.Object);
        }
    }
}
