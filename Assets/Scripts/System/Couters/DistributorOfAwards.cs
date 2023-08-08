using EventBusSystem;
using Services;
using Services.Economic;
using UnityEngine;

public class DistributorOfAwards : MonoBehaviour, IPlayerChangeSizeHandler, IGameEndHandler, IGameSartHandler
{
    private float _startIncraseTime;
    private IBankService _bankService;
    private IScoreService _scoreService;
    private IScoreToValuteConvertor _toValuteConvertor;
    private ITimeToScoreConvertor _timeToScoreConvertor;

    private void OnEnable()
    {
        EventBus.Subscribe(this);
        _toValuteConvertor = new ScoreToValuteConvertor();
        _bankService = ServiceLockator.instance.GetService<IBankService>();
        _scoreService = ServiceLockator.instance.GetService<IScoreService>();
        _timeToScoreConvertor = new TimeToScoreConvertor();
    }
    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    public void GameStart()
    {
        _scoreService.SessionStart();
    }

    public void OnPlayerStartIncrease()
    {
        _startIncraseTime = Time.time;
    }
    public void OnPlayerEndIncrease()
    {
        float increaseTime = Time.time - _startIncraseTime;
        _scoreService.AddScore(_timeToScoreConvertor.ConvertToScore(increaseTime));
    }
    public void GameEnd()
    {
        _scoreService.SessionEnd();
        _bankService.AddValue(_toValuteConvertor.CalculateValute(_scoreService.currentGameScore));
    }
}
