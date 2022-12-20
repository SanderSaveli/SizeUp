using System;
using UnityEngine;

[Serializable]
public class BackgroundThemePrisets
{
    [SerializeField] private Sprite _background;

    public Sprite Background => _background;
}
