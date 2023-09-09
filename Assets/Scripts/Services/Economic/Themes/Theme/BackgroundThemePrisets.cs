using System;
using UnityEngine;

[Serializable]
public class BackgroundTheme
{
    [SerializeField] private Sprite _background;
    [SerializeField] private Color _figureColor = Color.white;
    [SerializeField] private Color _currentScoreColor = Color.white;
    [SerializeField] private Color _inscriptionsColor = Color.white;

    public Sprite background => _background;
    public Color figureColor => _figureColor;
    public Color currentScoreColor => _currentScoreColor;
    public Color inscriptionsColor => _inscriptionsColor;
}
