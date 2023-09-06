using System;
using UnityEngine;

[Serializable]
public class BackgroundTheme
{
    [SerializeField] private Sprite _background;
    [SerializeField] private Color _figureColor = Color.white;

    public Sprite Background => _background;
    public Color FigureColor => _figureColor;
}
