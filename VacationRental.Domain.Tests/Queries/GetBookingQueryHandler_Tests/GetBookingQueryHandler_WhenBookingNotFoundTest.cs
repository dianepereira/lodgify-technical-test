using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using VacationRental.Domain.Core.Entities;
using VacationRental.Domain.Core.Exceptions;
using VacationRental.Domain.Queries.GetBooking;

namespace VacationRental.Domain.Tests.Queries.GetBookingQueryHandler_Tests
{
    public class GetBookingQueryHandler_WhenBookingNotFoundTest : GetBookingQueryHandler_BaseTests
    {
        private GetBookingQuery QueryCommand;

        [SetUp]
        public void Arrange()
        {
            QueryCommand = Fixture
                .Build<GetBookingQuery>()
                .Create();

            BookingRepositoryMock
                .Setup(repository => repository.Get(It.IsAny<int>()))
                .Returns(It.IsAny<Booking>());
        }

        public Func<Task> Act => async () => _ = await GetBookingQueryHandler.Handle(QueryCommand, CancellationToken);

        [Test]
        public void Assert()
        {
            Act.Should().ThrowAsync<RentalBookingNotFoundException>();


            BookingRepositoryMock
                .Verify(repository => repository.Get(It.IsAny<int>()), Times.Once);
        }
    }
}
