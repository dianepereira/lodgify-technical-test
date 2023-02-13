using AutoFixture;
using Moq;
using NUnit.Framework;
using VacationRental.Domain.Core.Repositories;
using VacationRental.Domain.Queries.GetBooking;

namespace VacationRental.Domain.Tests.Queries.GetBookingQueryHandler_Tests
{
    public class GetBookingQueryHandler_BaseTests
    {
        protected Mock<IBookingRepository> BookingRepositoryMock;
        protected GetBookingQueryHandler GetBookingQueryHandler;
        protected CancellationToken CancellationToken;
        protected Fixture Fixture;

        [SetUp]
        public void SetUp()
        {
            BookingRepositoryMock = new();
            CancellationToken = new();
            Fixture = new();

            GetBookingQueryHandler = new GetBookingQueryHandler(
                BookingRepositoryMock.Object);
        }
    }
}
