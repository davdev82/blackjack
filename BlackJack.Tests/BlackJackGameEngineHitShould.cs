using BlackJack.Entities;
using BlackJack.Helpers;
using Moq;
using NUnit.Framework;

namespace BlackJack.Tests
{
    [TestFixture]
    public class BlackJackGameEngineHitShould
    {
        private BlackJackGameEngine _blackJackGame;
        private Player _player;        
        private Mock<IDealer> _mockDealer = new Mock<IDealer>();

        [SetUp]
        public void Setup()
        {            
            _player = new Player("John");                           
        }

        [Test]
        public void CallDealPlayer()
        {
            _blackJackGame = new BlackJackGameEngine(_player, _mockDealer.Object);
            _blackJackGame.Start();

            _blackJackGame.Hit();

            _mockDealer.Verify(s => s.DealPlayer(It.IsAny<Player>()), Times.Once);
        }

        [Test]
        public void UpdateGameStatusToDealerWins()
        {
            _blackJackGame = new BlackJackGameEngine(_player, _mockDealer.Object);
            _player.Hand.Add(new Card(Suit.Clubs, FaceName.Ten, new FaceValue(10)));
            _player.Hand.Add(new Card(Suit.Hearts, FaceName.Ten, new FaceValue(10)));

            _mockDealer.Setup(s => s.DealPlayer(It.IsAny<Player>()))
                .Callback(() => _player.Hand.Add(new Card(Suit.Clubs, FaceName.Ace, new FaceValue(1, 11))));
            
            _blackJackGame.Start();         

            _blackJackGame.Hit();
            
            Assert.IsTrue(_blackJackGame.GameStatus == GameStatus.DealerWins);
        }
    }
}