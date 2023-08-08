using Services.Economic;
using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LastScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Animation  _animation;
    private IScoreService _scoreService;
    private void OnEnable()
    {
        _scoreService = ServiceLockator.instance.GetService<IScoreService>();
        _scoreService.NewLastIncreaseChanged += ChangeScore;
    }

    private void OnDisable()
    {
        _scoreService.NewLastIncreaseChanged -= ChangeScore;
    }

    private void ChangeScore(int score)
    {
        _scoreText.text = score.ToString();
        _animation.Play();
    }
}