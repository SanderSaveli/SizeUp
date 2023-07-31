using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using ViewElements;

public abstract class Button : MonoBehaviour
{
    public AnimationClip ShowAnimation;
    public AnimationClip HideAnimation;

    private Animation animation;

    public abstract void Click();

    private void OnEnable()
    {
        animation = GetComponent<Animation>();
        ButtonTheme theme = 
            GameObject.FindObjectOfType<ThemeRepository>().GetActiveButtonTheme();
        IniTheme(theme);
    }
    public void IniTheme(ButtonTheme theme) 
    {
        gameObject.GetComponent<Image>().color = theme.ButtonColor;
        transform.GetChild(0).GetComponent<Image>().color = theme.IconColor;
    }

    public virtual void Show() 
    {
        animation.clip = ShowAnimation;
        animation.Play();
    }
    public virtual void Hide() 
    {
        animation.clip = HideAnimation;
        animation.Play();
        StartCoroutine(RemoveAfterAnimationEnd(animation.clip.length));
    }
    private IEnumerator RemoveAfterAnimationEnd(float animationDuration) 
    {
        yield return new WaitForSeconds(animationDuration);
        Destroy(gameObject);
    }
}
