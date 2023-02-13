using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationRental.Domain.Core.Entities;
using VacationRental.Domain.Queries.GetBooking;
using VacationRental.Domain.Queries.GetRental;
using VacationRental.Domain.Tests.Queries.GetBookingQueryHandler_Tests;

namespace VacationRental.Domain.Tests.Queries.GetCalendarQueryHandler_Tests
{
    public class GetRentalQueryHandler_WhenRentalExistsTest : GetRentalQueryHandler_BaseTests
    {
        private GetRentalQuery QueryCommand;

        [SetUp]
        public void Arrange()
        {
            var bookingEntity = Fixture
                .Build<Rental>()
                .Create();

            QueryCommand = Fixture
                .Build<GetRentalQuery>()
                .Create();

            RentalRepositoryMock
                .Setup(repository => repository.Get(It.IsAny<int>()))
                .Returns(bookingEntity);
        }

        public Func<Task> Act => async () => _ = await GetRentalQueryHandler.Handle(QueryCommand, CancellationToken);

        [Test]
        public void Assert()
        {
            Act.Should().NotThrowAsync();

            RentalRepositoryMock
                .Verify(repository => repository.Get(It.IsAny<int>()), Times.Once);
        }
    }
}
