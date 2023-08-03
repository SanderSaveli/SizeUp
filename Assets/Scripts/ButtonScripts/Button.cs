using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using ViewElements;

public abstract class Button : MonoBehaviour
{
    public AnimationClip showAnimation;
    public AnimationClip hideAnimation;

    [SerializeField] private Image _frontTexture;
    [SerializeField] private Image _shadow;
    [SerializeField] private Image _icon;

    private Animation _animation;
    private GameObject _buttonVisual;

    public abstract void Click();

    private void OnEnable()
    {
        _animation = GetComponent<Animation>();
        _buttonVisual = transform.GetChild(0).gameObject;
    }
    public void IniTheme(ButtonTheme theme) 
    {
        _frontTexture.color = theme.ButtonColor;
        _icon.color = theme.IconColor;
    }

    public virtual void Show() 
    {
        ButtonTheme theme =
            ThemeRepository.instance.GetActiveButtonTheme();
        IniTheme(theme);
        _buttonVisual.SetActive(true);
        _animation.clip = showAnimation;
        _animation.Play();
    }
    public virtual void Hide() 
    {
        _animation.clip = hideAnimation;
        _animation.Play();
        StartCoroutine(DissableAfterAnimationEnd(_animation.clip.length));
    }
    private IEnumerator DissableAfterAnimationEnd(float animationDuration) 
    {
        yield return new WaitForSeconds(animationDuration);
        _buttonVisual.SetActive(false);
    }
}
