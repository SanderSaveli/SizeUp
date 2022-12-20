using System;
using UnityEngine;

[Serializable]
public class PlayerThemePresets
{
    [SerializeField] private Sprite _playerBall;

    public Sprite PlayerBall => _playerBall;
}
