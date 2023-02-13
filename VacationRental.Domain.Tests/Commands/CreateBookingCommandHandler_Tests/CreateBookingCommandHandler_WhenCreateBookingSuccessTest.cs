﻿using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using VacationRental.Domain.Commands.CreateBooking;
using VacationRental.Domain.Core.Entities;

namespace VacationRental.Domain.Tests.Commands.CreateBookingCommandHandler_Tests
{
    public class CreateBookingCommandHandler_WhenCreateBookingSuccessTest : CreateBookingCommandHandler_BaseTest
    {
        private CreateBookingCommand Command;

        [SetUp]
        public void Arrange()
        {
            var rentalEntity = Fixture
                .Build<Rental>()
                .Create();

            var bookingEntity = Fixture
                .Build<Booking>()
                .Create();

            Command = new CreateBookingCommand(2, DateTime.Now, 3, 2);

            RentalRepositoryMock
                .Setup(repository => repository.Get(It.IsAny<int>()))
                .Returns(rentalEntity);

            BookingRepositoryMock
                .Setup(repository => repository.IsBookingAvaiable(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<int>()))
                .Returns(true);

            BookingRepositoryMock
                .Setup(repository => repository.Add(It.IsAny<Booking>()))
                .Returns(bookingEntity);
        }

        public Func<Task> Act => async () => _ = await CreateBookingCommandHandler.Handle(Command, CancellationToken);

        [Test]
        public void Assert()
        {
            Act.Should().NotThrowAsync();

            RentalRepositoryMock
                .Verify(repository => repository.Get(It.IsAny<int>()), Times.Once());

            BookingRepositoryMock
               .Verify(repository => repository.IsBookingAvaiable(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<int>()), Times.Once);

            BookingRepositoryMock
              .Verify(repository => repository.Add(It.IsAny<Booking>()), Times.Once);
        }
    }
}
