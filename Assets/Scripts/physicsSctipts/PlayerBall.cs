using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : Ball
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
    public void IniTheme(PlayerThemePresets presets)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = presets.PlayerBall;
    }
}
