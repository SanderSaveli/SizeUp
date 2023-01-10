using UnityEngine;
using UnityEngine.UI;

public abstract class Button : MonoBehaviour
{
    public AnimationClip ShowAnimation;
    public AnimationClip HideAnimation;

    public abstract void Click();

    public void IniTheme(ButtonThemePresets presets) 
    {
        gameObject.GetComponent<Image>().color = presets.ButtonColor;
        transform.GetChild(0).GetComponent<Image>().color = presets.IconColor;
    }

    public virtual void Show() 
    {
        Animation animation = gameObject.GetComponent<Animation>();
        animation.clip = ShowAnimation;
        animation.Play();
    }
    public virtual void Hide() 
    {
        Animation animation = gameObject.GetComponent<Animation>();
        animation.clip = HideAnimation;
        animation.Play();
    }
}
