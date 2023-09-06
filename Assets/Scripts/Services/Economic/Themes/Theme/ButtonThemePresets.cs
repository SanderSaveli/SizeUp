using System;
using UnityEngine;

[Serializable]
public class ButtonTheme
{
    [SerializeField] private Color _buttonColor = Color.white;
    [SerializeField] private Color _iconColor = Color.white;

    public Color ButtonColor => _buttonColor;
    public Color IconColor => _iconColor;
}
