using BlackJack.Entities;
using Moq;
using NUnit.Framework;

namespace BlackJack.Tests
{
    [TestFixture]
    public class BlackJackGameEngineStickShould
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
        public void CallDealRequiredNumberOfTimes()
        {
            _mockDealer.SetupProperty(d => d.Hand, new Hand());
            _blackJackGame = new BlackJackGameEngine(_player, _mockDealer.Object);
            _blackJackGame.Start();
            _mockDealer.Setup(s => s.Deal())
                .Callback(() => _mockDealer.Object.Hand.Add(new Card(Suit.Clubs, FaceName.Ace, new FaceValue(1, 11))));

            _blackJackGame.Stick();
            _mockDealer.Verify(s => s.Deal(), Times.Exactly(17));
        }

        [Test]
        public void UpdateGameStatusToPlayerWins()
        {
            int callCount = 0;
            _mockDealer.SetupProperty(d => d.Hand, new Hand());
            _blackJackGame = new BlackJackGameEngine(_player, _mockDealer.Object);
            _blackJackGame.Start();
            _mockDealer.Setup(s => s.Deal())
                .Callback(() =>
                {
                    if (callCount == 0)
                    {
                        _mockDealer.Object.Hand.Add(new Card(Suit.Clubs, FaceName.Ten, new FaceValue(10)));
                        callCount++;
                        return;
                    }

                    if (callCount == 1)
                    {
                        _mockDealer.Object.Hand.Add(new Card(Suit.Clubs, FaceName.Five, new FaceValue(5)));
                        callCount++;
                        return;
                    }

                    if (callCount == 2)
                    {
                        _mockDealer.Object.Hand.Add(new Card(Suit.Clubs, FaceName.Ten, new FaceValue(10)));
                        callCount++;
                        return;
                    }

                });

            _blackJackGame.Stick();         
            Assert.IsTrue(_blackJackGame.GameStatus == GameStatus.PlayerWins);
        }
    }
}