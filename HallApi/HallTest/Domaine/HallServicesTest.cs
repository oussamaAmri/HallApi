using HallDomain.Interfaces;
using HallDomain.Models;
using HallDomain.Services;
using NFluent;
using NSubstitute;

namespace HallTest.Domaine;

public class HallServicesTest
{
    [Fact]
    public async Task Should_IHallService_Return_halls()
    {
        //Arrange
        var ihallRepository = Substitute.For<IHallRepository>();
        var halls = new List<Hall>
        {
            new Hall { Id = 1, Name = "room1" },
            new Hall { Id = 2, Name = "room2" }
        };
        ihallRepository.GetHallsAsync().Returns(halls);
        var hallService = new HallService(ihallRepository);

        //Act
        var result = await hallService.GetHallsAsync();

        //Asert
        Check.That(result).HasSize(2);
        Check.That(result.ElementAt(0).Name).IsEqualTo("room1");
        Check.That(result.ElementAt(1).Name).IsEqualTo("room2");
    }
}
