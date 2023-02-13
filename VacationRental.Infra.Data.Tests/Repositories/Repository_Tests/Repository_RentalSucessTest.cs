using FluentAssertions;
using Moq;
using NUnit.Framework;
using VacationRental.Domain.Core.Entities;

namespace VacationRental.Infra.Data.Tests.Repositories.Repository_Tests
{
    public class Repository_RentalSucessTest : Repository_Test
    {
        private int Id;
        private Rental RentalEntity;

        [SetUp]
        public void Arrange()
        {
            RentalEntity = new Rental(1, 1);
            Id = 1;

        }

        public Rental AddAct => RentalRepository.Add(RentalEntity);
        public Rental? GetAct => RentalRepository.Get(Id);
        public IEnumerable<Rental> GetAllAct => RentalRepository.GetAll();


        [Test]
        public void Assert()
        {
            AddAct.Should().NotBeNull();
            GetAct.Should().NotBeNull();
            GetAllAct.Should().NotBeNull();
        }
    }
}
