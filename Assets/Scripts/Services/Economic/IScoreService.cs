namespace Services.Economic
{
    public interface IScoreService : IService
    {
        public delegate void ScoreChanged(int score);
        public event ScoreChanged OnBestScoreChanged;
        public event ScoreChanged OnCurrentGameScoreChanged;
        public event ScoreChanged NewLastIncreaseChanged;
        public int bestScore {get;}
        public int currentGameScore {get;}
        public int lastScoreIncrease { get;}

        public void AddScore(int score);
        /// <summary>
        /// Returns this session score
        /// </summary>
        /// <returns></returns>
        public int SessionEnd();

        public void SessionStart();

    }
}
