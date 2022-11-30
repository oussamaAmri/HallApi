using Azure;
using HallApi.Controllers;
using HallDomain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NFluent;
using NSubstitute;
using NSubstitute.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallTest.Api
{
    public class HallControllerTest
    {
        [Fact]
        public async Task Should_GetHallsAsync_Return_halls()
        {
            //Arrange
            var hallservice = Substitute.For<IHallService>();
            var halls = new List<string> { "room1", "room2" };
            hallservice.GetHallsAsync().Returns(halls); 
            var hallController = new HallController(hallservice);
            //Act

            var result = await hallController.GetHallsAsync();

            //Asert

 //           Check.That(result).IsInstanceOf<ObjectResult>();

            var objectResult = (ObjectResult)result;
            Check.That(objectResult.StatusCode).IsEqualTo(200);

            var returnedHalls = (IEnumerable<string>)objectResult.Value;
            Check.That(returnedHalls).HasSize(2);
        }
    }
}
