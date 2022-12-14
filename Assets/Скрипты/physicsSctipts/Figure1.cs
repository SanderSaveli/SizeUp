using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Figure1 : MonoBehaviour
{
    public GameObject[] Figures;
    public Sprite[] Themes;
    public GameObject BG;
    public Text TotalScoreTxt;
    public Color[] TxtColor;
    public Sprite[] PlayerSkin;
    public GameObject Player;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Themes"))
        {
            for (int i = 1; i < Themes.Length; i++)
            {
                PlayerPrefs.SetString(i.ToString() + "T", "Lock");
            }
            for (int i = 0; i < Figures.Length; i++)
            {
                PlayerPrefs.SetString(i.ToString() , "Lock");
            }
            PlayerPrefs.SetInt("Themes",0);
            PlayerPrefs.SetInt("Figures", 0);
            PlayerPrefs.SetString("0", "Select");
            PlayerPrefs.SetString("0T", "Select");
            PlayerPrefs.SetInt("Crystal", 0);
            PlayerPrefs.SetInt("BestScore", 0);
            PlayerPrefs.SetString("Sound", "On");
            PlayerPrefs.SetString("Music", "On");
        }
        Player.GetComponent<SpriteRenderer>().sprite = PlayerSkin[PlayerPrefs.GetInt("Themes")];
        BG.GetComponent<SpriteRenderer>().sprite = Themes[PlayerPrefs.GetInt("Themes")];

        TotalScoreTxt.color = TxtColor[PlayerPrefs.GetInt("Themes")];

        Figures[PlayerPrefs.GetInt("Figures")].gameObject.SetActive(true);
        if (PlayerPrefs.GetString("Music")=="Off")
        {
            GetComponent<AudioSource>().mute = true;
        }
    }
   


}