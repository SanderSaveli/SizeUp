using System;
using UnityEngine;

[Serializable]
public class EnemyTheme
{
    [SerializeField] private Sprite _enemyBall;

    public Sprite EnemyBall => _enemyBall;
}
