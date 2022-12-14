using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private Transform Tr;
    public GameObject MusicB;
    public readonly float checkPos = -4.5f;
    public readonly float speed = 0.2f;
    private bool IsTap;
    public Sprite[] Themes;
    public Sprite[] OffTheme;
    private void Start()
    {
        if (PlayerPrefs.GetString("Music")=="Off")   
            GetComponent<SpriteRenderer>().sprite = OffTheme[PlayerPrefs.GetInt("Themes")];
        else
            GetComponent<SpriteRenderer>().sprite = Themes[PlayerPrefs.GetInt("Themes")];
        
        Tr = GetComponent<Transform>();

    }

    private void FixedUpdate()
    {
        IsTap = GameObject.Find("SettingsButton").GetComponent<Button>().istap;
        if (IsTap)
        {
            if (Tr.position.y < checkPos)
                Tr.position += new Vector3(0, speed, 0f);
        }
        else if (Tr.position.y > -6.5)
            Tr.position -= new Vector3(0, speed, 0f);
        else if (Tr.position.y <= -6.5)
            MusicB.gameObject.SetActive(false);
    }

    private void OnMouseUp()
    {
        if (PlayerPrefs.GetString("Music") == "Off") 
        {
            PlayerPrefs.SetString("Music","On") ;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().mute = false;
            GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite = Themes[PlayerPrefs.GetInt("Themes")]; ;
        }
        else
        {
            PlayerPrefs.SetString("Music", "Off");
            GameObject.Find("Main Camera").GetComponent<AudioSource>().mute = true;
            GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite = OffTheme[PlayerPrefs.GetInt("Themes")];
        }

        
    }

}
