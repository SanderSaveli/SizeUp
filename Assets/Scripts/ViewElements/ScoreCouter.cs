using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCouter : MonoBehaviour, ITouchHandler
{
    [SerializeField] private Text scoreText;
    private float increaseTime;
    private void OnEnable()
    {
        EventBus.Subscribe(this);
    }

    private void StartScoreCouting() 
    { 
        
    }
    private IEnumerator ScoreCouting() 
    {
        while (true) 
        {
            increaseTime += Time.deltaTime;
            yield return null;
        }
    }
    private void StopScoreCouting() { }

    void ITouchHandler.StartTouch()
    {
        StartCoroutine(ScoreCouting());
    }

    void ITouchHandler.EndTouch()
    {
        throw new System.NotImplementedException();
    }
}
