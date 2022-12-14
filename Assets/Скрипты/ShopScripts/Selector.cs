using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Selector : MonoBehaviour
{
    public Text Crystaltxt;
    public AudioClip SelectSound;
    public AudioClip BuyingSound;
    public int[] FigureCost;
    public int[] ThemeCost;
    public Sprite[] ThemeSelect;
    public Sprite[] ThemeOpen;
    public Sprite[] ThemeLock;
    public Sprite[] FigureSelect;
    public Sprite[] FigureOpen;
    public Sprite[] FigureLock;
    private GameObject NowSelectTheme;
    private int NSThemeIndex;
    private GameObject NowSelectFigure;
    private int NSFigureIndex;
    private GameObject gm; //переменная для хранения разных gm
    private void Start()
    {
        for (int i = 0; i < FigureCost.Length; i++)
        {
            gm = GameObject.Find("Figure"+i.ToString());
            switch (PlayerPrefs.GetString(i.ToString()))
            {
                case "Open":
                    gm.GetComponent<Image>().sprite = FigureOpen[i];
                    break;
                case "Lock":
                    gm.GetComponent<Image>().sprite = FigureLock[i];
                    break;
                case "Select":
                    gm.GetComponent<Image>().sprite = FigureSelect[i];
                    NowSelectFigure = gm;
                    NSFigureIndex = i;
                    break;
            }   
        }
        for (int i = 0; i < ThemeCost.Length; i++) //установка нужных спрайтов при загрузке
        {
            gm = GameObject.Find("Theme" + i.ToString());
            switch (PlayerPrefs.GetString(i.ToString()+"T"))
            {
                case "Open":
                    gm.GetComponent<Image>().sprite = ThemeOpen[i];
                    break;
                case "Lock":
                    gm.GetComponent<Image>().sprite = ThemeLock[i];
                    break;
                case "Select":
                    gm.GetComponent<Image>().sprite = ThemeSelect[i];
                    NowSelectTheme = gm;
                    NSThemeIndex = i;
                    break;
            }
        }
        GameObject.Find("Themes").SetActive(false);
    }
    public void sound(AudioClip AC)
    {
        if (PlayerPrefs.GetString("Sound") == "On")
        {
            GetComponent<AudioSource>().clip = AC;
            GetComponent<AudioSource>().Play();
        }
    }
    
    public void SetFigure(int index)//нажатие на кнопку фигуры
    {
        if(PlayerPrefs.GetString(index.ToString())=="Open"&& NowSelectFigure!= GameObject.Find("Figure" + index.ToString()) ) 
        {
            PlayerPrefs.SetInt("Figures", index); //установка значения фигуры
            gm = GameObject.Find("Figure" + index.ToString());
            NowSelectFigure.GetComponent<Image>().sprite = FigureOpen[NSFigureIndex];
            PlayerPrefs.SetString(NSFigureIndex.ToString(), "Open");
            gm.GetComponent<Image>().sprite = FigureSelect[index];
            PlayerPrefs.SetString(index.ToString(), "Select");
            NowSelectFigure = gm;
            NSFigureIndex = index;
            sound(SelectSound);
        }
        else if (PlayerPrefs.GetInt("Crystal")>=FigureCost[index]&& PlayerPrefs.GetString(index.ToString()) == "Lock")
        {
            PlayerPrefs.SetInt("Crystal", PlayerPrefs.GetInt("Crystal")-FigureCost[index]);
            Crystaltxt.text = PlayerPrefs.GetInt("Crystal").ToString();
            gm = GameObject.Find("Figure" + index.ToString());
            gm.GetComponent<Image>().sprite = FigureOpen[index];
            PlayerPrefs.SetString(index.ToString(), "Open");
            sound(BuyingSound);
        }

    }
    public void SetTheme (int Index) //нажатие на кнопку темы
    {
        if (PlayerPrefs.GetString(Index.ToString()+"T") == "Open"&&NowSelectTheme!= GameObject.Find("Theme" + Index.ToString()))
        {
            PlayerPrefs.SetInt("Themes", Index);
            gm = GameObject.Find("Theme" + Index.ToString());
            NowSelectTheme.GetComponent<Image>().sprite = ThemeOpen[NSThemeIndex];
            PlayerPrefs.SetString(NSThemeIndex.ToString()+"T", "Open");
            gm.GetComponent<Image>().sprite = ThemeSelect[Index];
            PlayerPrefs.SetString(Index.ToString()+"T", "Select");
            NowSelectTheme = gm;
            NSThemeIndex = Index;
            sound(SelectSound);
        }
        else if (PlayerPrefs.GetInt("Crystal") >= ThemeCost[Index]&& PlayerPrefs.GetString(Index.ToString()+"T") == "Lock")
        {
            PlayerPrefs.SetInt("Crystal", PlayerPrefs.GetInt("Crystal") - ThemeCost[Index]);
            Crystaltxt.text = PlayerPrefs.GetInt("Crystal").ToString();
            gm = GameObject.Find("Theme" + Index.ToString());
            gm.GetComponent<Image>().sprite = ThemeOpen[Index];
            PlayerPrefs.SetString(Index.ToString() + "T", "Open");
            sound(BuyingSound);
        }
    }
    

}
