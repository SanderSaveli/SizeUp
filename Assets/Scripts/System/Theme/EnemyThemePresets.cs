using System;
using UnityEngine;

[Serializable]
public class EnemyThemePresets
{
    [SerializeField] private Sprite _enemyBall;

    public Sprite EnemyBall => _enemyBall;
}
