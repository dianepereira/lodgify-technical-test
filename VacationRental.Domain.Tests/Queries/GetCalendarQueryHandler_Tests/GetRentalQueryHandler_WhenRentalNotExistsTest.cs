using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using VacationRental.Domain.Core.Entities;
using VacationRental.Domain.Core.Exceptions;
using VacationRental.Domain.Queries.GetRental;

namespace VacationRental.Domain.Tests.Queries.GetCalendarQueryHandler_Tests
{
    public class GetRentalQueryHandler_WhenRentalNotExistsTest : GetRentalQueryHandler_BaseTests
    {
        private GetRentalQuery QueryCommand;

        [SetUp]
        public void Arrange()
        {
            QueryCommand = Fixture
                .Build<GetRentalQuery>()
                .Create();

            RentalRepositoryMock
                .Setup(repository => repository.Get(It.IsAny<int>()))
                .Returns(It.IsAny<Rental>());
        }

        public Func<Task> Act => async () => _ = await GetRentalQueryHandler.Handle(QueryCommand, CancellationToken);

        [Test]
        public void Assert()
        {
            Act.Should().ThrowAsync<RentalNotFoundException>();

            RentalRepositoryMock
                .Verify(repository => repository.Get(It.IsAny<int>()), Times.Once());
        }
    }
}
