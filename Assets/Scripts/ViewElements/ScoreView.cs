using Services;
using Services.Economic;
using UnityEngine;
using TMPro;

namespace ViewElements 
{ 
    public class ScoreView : ThemeChanged
    {
        [SerializeField] private TMP_Text _scoreText;
        private IScoreService _scoreService;
        private void OnEnable()
        {
            _scoreService = ServiceLockator.instance.GetService<IScoreService>();
            _scoreService.OnCurrentGameScoreChanged += ChangeScore;
        }

        private void OnDisable()
        {
            _scoreService.OnCurrentGameScoreChanged -= ChangeScore;
        }

        private void ChangeScore(int score) 
        {
            _scoreText.text = score.ToString();
        }

        public override void ChangeTheme(Theme theme)
        {
            _scoreText.color = theme.BackgroundTheme.scoreColor;
        }
    }
}

