using System.Collections.Generic;
using System.Linq;
using Moq;
using jenkinsDemo;
using jenkinsDemo.Controllers;
using jenkinsDemo.Models;
using NUnit.Framework;

namespace jenkinsDemoTests
{
    public class Tests
    {
        private readonly Mock<IBallDontLieManager> _ballDontLieManagerMock = new();
        private PlayersController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new PlayersController(_ballDontLieManagerMock.Object);
        }

        [Test]
        public void GetPlayers_Success_ReturnPlayers()
        {
            Player player = new("Zach", "Sarkis");

            _ballDontLieManagerMock.Setup(m => m.GetPlayers())
                .Returns(new List<Player> {player});

            List<Player> result = _controller.GetPlayers().ToList();

            //_ballDontLieManagerMock.Verify(m => m.GetPlayers(), Times.Once);
            Assert.That(result.First().first_name == player.first_name);
            Assert.That(result.First().last_name == player.last_name);
        }
        
        [Test]
        public void GetPlayers_Fail_ReturnPlayers()
        {
            Player player = new("Zach", "Sarkis");

            _ballDontLieManagerMock.Setup(m => m.GetPlayers())
                .Returns(new List<Player> {player});

            List<Player> result = _controller.GetPlayers().ToList();
            
            //_ballDontLieManagerMock.Verify(m => m.GetPlayers(), Times.Once);
            Assert.That(result.First().first_name == player.first_name);
            Assert.AreNotEqual(result.First().last_name,string.Empty);
        }
    }
}