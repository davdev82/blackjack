using BlackJack.Entities;

namespace BlackJack
{
    public class BlackJackGameEngine
    {
        private readonly Player _player;
                
        private readonly IDealer _dealer;

        private const int ScoreLimit = 21;

        private const int DealerLowerLimit = 17;

        public GameStatus GameStatus { get; private set; }

        public BlackJackGameEngine(Player player, IDealer dealer)
        {
            _player = player;
            _dealer = dealer;
            GameStatus = GameStatus.NotStarted;
        }

        public void Start()
        {
            if (GameStatus == GameStatus.NotStarted)
            {               
                _dealer.Init(_player);
                GameStatus = GameStatus.InProgress;
            }
        }

        public void Hit()
        {
            if (GameStatus == GameStatus.InProgress)
            {
                _dealer.DealPlayer(_player);
                GameStatus = (_player.Hand.Total() >= ScoreLimit) ? GameStatus.DealerWins : GameStatus.InProgress;
            }
        }

        public void Stick()
        {
            if (GameStatus == GameStatus.InProgress)
            {
                while (_dealer.Hand.Total() < DealerLowerLimit && GameStatus == GameStatus.InProgress)
                {
                    _dealer.Deal();
                    GameStatus = (_dealer.Hand.Total() >= ScoreLimit) ? GameStatus.PlayerWins : GameStatus.InProgress;                    
                }         
            }

            if (GameStatus == GameStatus.InProgress)
            {
                EvaluateWinner();
            }               
        }

        private void EvaluateWinner()
        {
            GameStatus = _dealer.Hand.Total() > _player.Hand.Total() ? GameStatus.DealerWins : GameStatus.PlayerWins;
        }        
    }
}
