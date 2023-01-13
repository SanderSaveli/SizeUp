using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : Button
{
    public override void Click()
    {
        EventBus.RaiseEvent<IGameSartHandler>(it => it.GameStart());
    }
}
