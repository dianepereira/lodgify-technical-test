using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationRental.Domain.Core.Entities;

namespace VacationRental.Infra.Data.Tests.Repositories.Repository_Tests
{
    public class Repository_RentalNotFoundTest : Repository_Test
    {
        private int Id;

        [SetUp]
        public void Arrange()
        {
            Id = 1;

        }

        public Rental? GetAct => RentalRepository.Get(Id);
        public IEnumerable<Rental> GetAllAct => RentalRepository.GetAll();


        [Test]
        public void Assert()
        {
            GetAct.Should().BeNull();
            GetAllAct.Should().BeEmpty();
        }
    }
}
