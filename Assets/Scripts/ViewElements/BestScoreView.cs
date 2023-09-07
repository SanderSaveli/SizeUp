using Services;
using Services.Economic;
using TMPro;
using UnityEngine;

namespace ViewElements 
{ 
    public class BestScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _bestScoreText;
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
    }
}


