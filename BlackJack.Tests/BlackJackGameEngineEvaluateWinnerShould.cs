using BlackJack.Entities;
using Moq;
using NUnit.Framework;

namespace BlackJack.Tests
{
    [TestFixture]
    public class BlackJackGameEngineEvaluateWinnerShould
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
        public void CorrectlyIndicateDealerWins()
        {
            _mockDealer.SetupProperty(d => d.Hand, new Hand());
            _blackJackGame = new BlackJackGameEngine(_player, _mockDealer.Object);

            _player.Hand.Add(new Card(Suit.Clubs, FaceName.Six, new FaceValue(6)));
            _player.Hand.Add(new Card(Suit.Hearts, FaceName.Six, new FaceValue(6)));

            _mockDealer.Object.Hand.Add(new Card(Suit.Clubs, FaceName.Eight, new FaceValue(8)));
            _mockDealer.Object.Hand.Add(new Card(Suit.Hearts, FaceName.Eight, new FaceValue(8)));


            _blackJackGame.Start();

            _mockDealer.Setup(s => s.DealPlayer(It.IsAny<Player>()))
              .Callback(() => _player.Hand.Add(new Card(Suit.Clubs, FaceName.Five, new FaceValue(5))));

            _mockDealer.Setup(s => s.Deal())
                .Callback(() => _mockDealer.Object.Hand.Add(new Card(Suit.Clubs, FaceName.Four, new FaceValue(4))));


            _blackJackGame.Hit();
            _blackJackGame.Stick();
            
            Assert.IsTrue(_blackJackGame.GameStatus == GameStatus.DealerWins);
        }

        [Test]
        public void CorrectlyIndicatePlayerWins()
        {
            _mockDealer.SetupProperty(d => d.Hand, new Hand());
            _mockDealer.Setup(s => s.DealPlayer(It.IsAny<Player>()))
              .Callback(() => _player.Hand.Add(new Card(Suit.Clubs, FaceName.Five, new FaceValue(5))));

            _player.Hand.Add(new Card(Suit.Clubs, FaceName.Five, new FaceValue(5)));
            _player.Hand.Add(new Card(Suit.Hearts, FaceName.Five, new FaceValue(5)));

            _mockDealer.Object.Hand.Add(new Card(Suit.Clubs, FaceName.Nine, new FaceValue(9)));
            _mockDealer.Object.Hand.Add(new Card(Suit.Hearts, FaceName.Nine, new FaceValue(9)));


            _blackJackGame = new BlackJackGameEngine(_player, _mockDealer.Object);

            _blackJackGame.Start();

            _blackJackGame.Hit();
            _blackJackGame.Hit();

            _blackJackGame.Stick();

            Assert.IsTrue(_blackJackGame.GameStatus == GameStatus.PlayerWins);
        }
    }
}