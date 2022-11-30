using HallApi.Controllers;
using HallDomain.Interfaces;
using HallDomain.Services;
using Microsoft.AspNetCore.Mvc;
using NFluent;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallTest.Domaine
{
    public class HallServicesTest
    {
        [Fact]
        public async Task Should_IHallService_Return_halls()
        {
            //Arrange
            var ihallRepository = Substitute.For<IHallRepository>();
            var halls = new List<string> { "room1", "room2" };
            ihallRepository.GetHallsAsync().Returns(halls);
            var hallService = new HallService(ihallRepository);
            //Act

            var result = await hallService.GetHallsAsync();

            //Asert

            Check.That(result).ContainsExactly("room1","room2");
        }
    }
}
