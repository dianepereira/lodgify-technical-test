using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using VacationRental.Domain.Core.Entities;
using VacationRental.Domain.Queries.GetBooking;

namespace VacationRental.Domain.Tests.Queries.GetBookingQueryHandler_Tests
{
    public class GetBookingQueryHandler_WhenBookingExistsTest : GetBookingQueryHandler_BaseTests
    {
        private GetBookingQuery QueryCommand;

        [SetUp]
        public void Arrange()
        {
            var bookingEntity = Fixture
                .Build<Booking>()
                .Create();

            QueryCommand = Fixture
                .Build<GetBookingQuery>()
                .Create();

            BookingRepositoryMock
                .Setup(repository => repository.Get(It.IsAny<int>()))
                .Returns(bookingEntity);
        }

        public Func<Task> Act => async () => _ = await GetBookingQueryHandler.Handle(QueryCommand, CancellationToken);

        [Test]
        public void Assert()
        {
            Act.Should().NotThrowAsync();

            BookingRepositoryMock
                .Verify(repository => repository.Get(It.IsAny<int>()), Times.Once);
        }
    }
}
