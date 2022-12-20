using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ball, IControllable
{
    [SerializeField] private float SizeIncreasePerSecondInPercent;
    private bool _isIncreases;

    public void StartPressing() 
    { 
        _isIncreases = true;
        StartCoroutine(Increas());
    }
    public void StopPressing() 
    { 
        _isIncreases = false;
    }

    private IEnumerator Increas() 
    {
        while (_isIncreases) 
        {
            ChangeSize();
            yield return null;
        }
    }

    private void ChangeSize() 
    {
        float ScaleCoefficent = SizeIncreasePerSecondInPercent * Time.deltaTime / 100 + 1;
        transform.localScale *= ScaleCoefficent;
    }
}
