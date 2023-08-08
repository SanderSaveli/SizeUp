using Services.StorageService;
namespace Services.Economic
{
    public class GameScoreService : IScoreService
    {
        public event IScoreService.ScoreChanged OnBestScoreChanged;
        public event IScoreService.ScoreChanged OnCurrentGameScoreChanged;
        public event IScoreService.ScoreChanged NewLastIncreaseChanged;

        public int bestScore
        {
            get => _bestScore;
            private set
            {
                _bestScore = value;
                OnBestScoreChanged?.Invoke(_bestScore);
            }
        }
        public int currentGameScore
        {
            get => _currentGameScore;
            private set
            {
                _currentGameScore = value;
                OnCurrentGameScoreChanged?.Invoke(_currentGameScore);
            }
        }

        public int lastScoreIncrease
        {
            get => _lastScoreIncrease;
            private set
            {
                _lastScoreIncrease = value;
                NewLastIncreaseChanged?.Invoke(_lastScoreIncrease);
            }
        }

        private int _bestScore;
        private int _currentGameScore;
        private int _lastScoreIncrease;

        private bool _isSessionStart;
        private IStoregeService _storegeService;
        private const string _loadKey = "BestScore";

        public void Initialize()
        {
            _storegeService = ServiceLockator.instance.GetService<IStoregeService>();
            LoadScore();
        }

        public void Shutdown()
        { }

        public void AddScore(int score)
        {
            if (score < 0)
            {
                throw new System.ArgumentException("Added account cannot be less than zero");
            }
            if (_isSessionStart)
            {
                currentGameScore += score;
                lastScoreIncrease = score;
            }
        }

        public void SessionStart()
        {
            _isSessionStart = true;
            currentGameScore = 0;
            _lastScoreIncrease = 0;
        }
        public int SessionEnd()
        {
            _isSessionStart = false;
            if (bestScore < currentGameScore)
            {
                bestScore = currentGameScore;
                SaveScore();
            }
            return currentGameScore;
        }

        private void SaveScore()
        {
            _storegeService.Save(_loadKey, currentGameScore);
        }
        private void LoadScore()
        {
            bestScore = _storegeService.Load<int>(_loadKey);
        }
    }
}


