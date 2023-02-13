using AutoFixture;
using Moq;
using NUnit.Framework;
using VacationRental.Domain.Core.Entities;
using VacationRental.Domain.Core.Repositories;
using VacationRental.Domain.Queries.GetCalendar;

namespace VacationRental.Domain.Tests.Queries.GetRentalQueryHandler_Tests
{
    public class GetRentalQueryHandler_BaseTests
    {
        protected Mock<IRepository<Rental>> RentalRepositoryMock;
        protected Mock<IBookingRepository> BookingRepositoryMock;
        protected GetCalendarQueryHandler GetCalendarQueryHandler;
        protected CancellationToken CancellationToken;
        protected Fixture Fixture;

        [SetUp]
        public void SetUp()
        {
            RentalRepositoryMock = new();
            BookingRepositoryMock = new();
            CancellationToken = new();
            Fixture = new();

            GetCalendarQueryHandler = new GetCalendarQueryHandler(
                RentalRepositoryMock.Object,
                BookingRepositoryMock.Object);
        }
    }
}
