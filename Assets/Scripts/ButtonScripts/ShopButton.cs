using UnityEngine;

public class ShopButton : Button, IMainMenuButton
{
    public override void Click()
    {
        Debug.Log("Shop");
    }
}
