using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationRental.Domain.Commands.CreateBooking;
using VacationRental.Domain.Core.Entities;
using VacationRental.Domain.Core.Exceptions;
using VacationRental.Domain.Queries.GetCalendar;

namespace VacationRental.Domain.Tests.Queries.GetRentalQueryHandler_Tests
{
    public class GetRentalQueryHandler_WhenRentalNotFoundTest : GetRentalQueryHandler_BaseTests
    {
        private GetCalendarQuery CommandQuery;

        [SetUp]
        public void Arrange()
        {
            CommandQuery = Fixture
                .Build<GetCalendarQuery>()
                .Create();

            RentalRepositoryMock
                .Setup(repository => repository.Get(It.IsAny<int>()))
                .Returns(It.IsAny<Rental>());
        }

        public Func<Task> Act => async () => _ = await GetCalendarQueryHandler.Handle(CommandQuery, CancellationToken);

        [Test]
        public void Assert()
        {
            Act.Should().ThrowAsync<RentalNotFoundException>();

            RentalRepositoryMock
                .Verify(repository => repository.Get(It.IsAny<int>()), Times.Once());
        }
    }
}
