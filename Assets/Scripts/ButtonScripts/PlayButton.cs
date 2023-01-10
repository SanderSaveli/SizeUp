using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class PlayButton : Button
{
    public override void Click()
    {
        EventBus.RaiseEvent<IGameSartHandler>(it => it.GameStart());
    }
}
