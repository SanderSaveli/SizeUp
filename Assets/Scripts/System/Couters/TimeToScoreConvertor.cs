using UnityEngine;

public class TimeToScoreConvertor : ITimeToScoreConvertor
{
    private const float pointsForOneSecond = 5;
    public int ConvertToScore(float time)
    {
        return Mathf.FloorToInt(time * pointsForOneSecond);
    }
}
