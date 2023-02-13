using AutoFixture;
using Moq;
using NUnit.Framework;
using VacationRental.Domain.Commands.CreateBooking;
using VacationRental.Domain.Core.Entities;
using VacationRental.Domain.Core.Repositories;

namespace VacationRental.Domain.Tests.Commands.CreateBookingCommandHandler_Tests
{
    public class CreateBookingCommandHandler_BaseTest
    {
        protected Mock<IRepository<Rental>> RentalRepositoryMock;
        protected Mock<IBookingRepository> BookingRepositoryMock;
        protected CreateBookingCommandHandler CreateBookingCommandHandler;
        protected CancellationToken CancellationToken;
        protected Fixture Fixture;

        [SetUp]
        public void SetUp()
        {
            RentalRepositoryMock = new();
            BookingRepositoryMock = new();
            CancellationToken = new();
            Fixture = new();

            CreateBookingCommandHandler = new CreateBookingCommandHandler(
                RentalRepositoryMock.Object,
                BookingRepositoryMock.Object);
        }
    }
}
