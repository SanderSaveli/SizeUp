using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public void IniTheme(BackgroundTheme presets) 
    {
        gameObject.GetComponent<Image>().sprite = presets.Background;
    }
}