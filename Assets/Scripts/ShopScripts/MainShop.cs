using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainShop : MonoBehaviour
{
    public Text crystaltxt;
    public GameObject MenuSvicher;
    public GameObject Themes;
    public GameObject Figures;
    public Sprite FigureMenu;
    public Sprite ThemeMenu;
    private void Start()
    {
        crystaltxt.text = PlayerPrefs.GetInt("Crystal").ToString();
        if (PlayerPrefs.GetString("Sound")=="Off")
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().enabled = false;
        }
    }
    public void ThemeOrFigure(int index)
    {
        if (index == 0)
        {
            MenuSvicher.GetComponent<SpriteRenderer>().sprite = FigureMenu;
            Themes.SetActive(false);
            Figures.SetActive(true);
        }
        else if (index == 1)
        {
            MenuSvicher.GetComponent<SpriteRenderer>().sprite = ThemeMenu;
            Themes.SetActive(true);
            Figures.SetActive(false);

        }
                
    }


}
