using BlackJack.Entities;
using BlackJack.Helpers;
using Moq;
using NUnit.Framework;

namespace BlackJack.Tests
{
    [TestFixture]
    public class BlackJackGameEngineStartShould
    {
        private BlackJackGameEngine _blackJackGame;
        private Player _player;        
        private Mock<IDealer> _mockDealer = new Mock<IDealer>();

        [SetUp]
        public void Setup()
        {            
            _player = new Player("John");            
            _blackJackGame = new BlackJackGameEngine(_player, _mockDealer.Object);            
        }

        [Test]
        public void SetTheGameStatusToInProgress()
        {
            _blackJackGame.Start();
            Assert.IsTrue(_blackJackGame.GameStatus == GameStatus.InProgress);
        }

        [Test]
        public void CallInit()
        {
            _blackJackGame.Start();
            _mockDealer.Verify(s => s.Init(It.IsAny<Player>()), Times.Once);
        }
    }
}