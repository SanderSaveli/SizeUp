using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : Ball
{
    public void IniTheme(EnemyTheme presets) 
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = presets.EnemyBall;
    }
}
