using AutoFixture;
using NUnit.Framework;
using VacationRental.Infra.Data.Repositories;

namespace VacationRental.Infra.Data.Tests.Repositories.BookingRepository_Tests
{
    public class BookingRepository_Test   
    {
        protected Fixture Fixture;
        protected BookingRepository BookingRepository;

        [SetUp]
        public void SetUp()
        {
            Fixture = new();
            BookingRepository = new BookingRepository();
        }
    }
}
