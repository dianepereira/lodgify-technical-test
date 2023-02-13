using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using VacationRental.Domain.Core.Entities;
using VacationRental.Domain.Queries.GetCalendar;

namespace VacationRental.Domain.Tests.Queries.GetRentalQueryHandler_Tests
{
    public class GetRentalQueryHandler_WhenGetCalendarSucessTest : GetRentalQueryHandler_BaseTests
    {
        private GetCalendarQuery CommandQuery;

        [SetUp]
        public void Arrange()
        {
            var bookingList = Fixture
                .Build<Booking>()
                .CreateMany();

            var rental = Fixture
                .Build<Rental>()
                .Create();

            CommandQuery = Fixture
                .Build<GetCalendarQuery>()
                .Create();

            RentalRepositoryMock
                .Setup(repository => repository.Get(It.IsAny<int>()))
                .Returns(rental);

            BookingRepositoryMock
                .Setup(repository => repository.GetBookingByRentalId(It.IsAny<int>()))
                .Returns(bookingList);
        }

        public Func<Task> Act => async () => _ = await GetCalendarQueryHandler.Handle(CommandQuery, CancellationToken);

        [Test]
        public void Assert()
        {
            Act.Should().NotThrowAsync();

            RentalRepositoryMock
                .Verify(repository => repository.Get(It.IsAny<int>()), Times.Once());

            BookingRepositoryMock
                .Verify(repository => repository.GetBookingByRentalId(It.IsAny<int>()), Times.Once);
        }
    }
}
