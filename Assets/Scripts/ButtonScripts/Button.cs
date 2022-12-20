using UnityEngine;
using UnityEngine.UI;

public abstract class Button : MonoBehaviour
{
    public ThemeRepository themeRepository;
    void Start()
    {
        ChangeColorByTheme(
            themeRepository.GetActiveTheme()
            );
    }

    private void ChangeColorByTheme(Theme theme)
    {
        gameObject.GetComponent<Image>().color = theme.ButtonColor;
        transform.GetChild(0).GetComponent<Image>().color = theme.IconColor;
    }

    public abstract void Click();
}
