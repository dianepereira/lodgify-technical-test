using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationRental.Domain.Core.Entities;
using VacationRental.Infra.Data.Repositories;

namespace VacationRental.Infra.Data.Tests.Repositories.BookingRepository_Tests
{
    public  class BookingRepository_BookingSucessTest : BookingRepository_Test
    {
        private int Id = 1;
        private int RentalId = 1;
        private int PreparationTimes = 1;
        private int RentalUnits = 3;
        private int BookingUnits = 2;
        private DateTime Start = DateTime.Now;
        private int Nights = 3;

        public IEnumerable<Booking> GetBookingAct => BookingRepository.GetBookingByRentalId(Id);

        public bool IsAvaiableAct => BookingRepository.IsBookingAvaiable(RentalId, PreparationTimes, RentalUnits, BookingUnits, Start, Nights);

        [Test]
        public void Assert()
        {
            GetBookingAct.Should().NotBeNull();
            IsAvaiableAct.Should().BeTrue();
        }
    }
}
