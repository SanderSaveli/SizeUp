using System;
using UnityEngine;

[Serializable]
public class BackgroundTheme
{
    [SerializeField] private Sprite _background;

    public Sprite Background => _background;
}
