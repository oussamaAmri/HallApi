using HallApi.Controllers;
using HallApi.Dtos.Responses;
using HallDomain.Interfaces;
using HallDomain.Models;
using Microsoft.AspNetCore.Mvc;
using NFluent;
using NSubstitute;

namespace HallTest.Api;

public class HallControllerTest
{
    [Fact]
    public async Task Should_GetHallsAsync_Return_halls()
    {
        //Arrange
        var hallservice = Substitute.For<IHallService>();
        var halls = new List<Hall>
        {
            new Hall { Id = 1, Name = "room1" },
            new Hall { Id = 2, Name = "room2" }
        };
        hallservice.GetHallsAsync().Returns(halls); 
        var hallController = new HallController(hallservice);
        //Act

        var result = await hallController.GetHallsAsync();

        //Asert

        Check.That(result).IsInstanceOf<OkObjectResult>();

        var objectResult = (ObjectResult)result;
        Check.That(objectResult.StatusCode).IsEqualTo(200);

        var returnedHalls = (HallsResponse)objectResult.Value;
        Check.That(returnedHalls.Halls).HasSize(2);
    }
}
