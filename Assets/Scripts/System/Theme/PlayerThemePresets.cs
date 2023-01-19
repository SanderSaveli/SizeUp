using System;
using UnityEngine;

[Serializable]
public class PlayerTheme
{
    [SerializeField] private Sprite _playerBall;

    public Sprite PlayerBall => _playerBall;
}
