using UnityEngine;
using UnityEngine.UI;

public abstract class Button : MonoBehaviour
{
    public abstract void Click();

    public void IniTheme(ButtonThemePresets theme) 
    {
        gameObject.GetComponent<Image>().color = theme.ButtonColor;
        transform.GetChild(0).GetComponent<Image>().color = theme.IconColor;
    }
}
