using System;
using UnityEngine;

[Serializable]
public class ButtonThemePresets
{
    [SerializeField] private Color _buttonColor;
    [SerializeField] private Color _iconColor;

    public Color ButtonColor => _buttonColor;
    public Color IconColor => _iconColor;
}
