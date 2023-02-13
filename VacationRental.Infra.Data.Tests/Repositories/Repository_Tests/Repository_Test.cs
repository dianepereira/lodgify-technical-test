using AutoFixture;
using Moq;
using NUnit.Framework;
using VacationRental.Domain.Core.Entities;
using VacationRental.Infra.Data.Repositories;

namespace VacationRental.Infra.Data.Tests.Repositories.Repository_Tests
{
    public class Repository_Test
    {
        protected Fixture Fixture;
        protected Mock<Repository<Rental>> RentalRepositoryMock;
        protected Repository<Rental> RentalRepository;

        [SetUp]
        public void SetUp()
        {
            Fixture = new();
            RentalRepositoryMock = new();
            RentalRepository = new Repository<Rental>();   
        }
    }
}
