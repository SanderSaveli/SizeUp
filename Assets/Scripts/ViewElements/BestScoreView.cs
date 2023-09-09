using Services;
using Services.Economic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ViewElements 
{ 
    public class BestScoreView : ThemeChanged
    {
        [SerializeField] private TMP_Text _bestScoreText;
        [SerializeField] private Text _bestInscription;
        private IScoreService _scoreService;
        private void OnEnable()
        {
            _scoreService = ServiceLockator.instance.GetService<IScoreService>();
            _scoreService.OnBestScoreChanged += ChangeBestScore;
            ChangeBestScore(_scoreService.bestScore);
        }


        private void OnDisable()
        {
            _scoreService.OnBestScoreChanged -= ChangeBestScore;
        }

        private void ChangeBestScore(int score)
        {
            _bestScoreText.text = score.ToString();
        }

        public override void ChangeTheme(Theme theme)
        {
            _bestScoreText.color = theme.BackgroundTheme.inscriptionsColor;
            _bestInscription.color = theme.BackgroundTheme.inscriptionsColor;
        }
    }
}


