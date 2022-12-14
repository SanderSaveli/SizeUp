using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    private Transform Tr;
    public GameObject SoundB;
    public readonly float checkPos = -2.5f;
    public readonly float speed = 0.2f;
    private bool IsTap;
    public Sprite[] Themes;
    public Sprite[] OffTheme;
    private void Start()
    {
        if (PlayerPrefs.GetString("Sound") == "Off")
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
            SoundB.gameObject.SetActive(false);
    }

    private void OnMouseUp()
    {
        if (PlayerPrefs.GetString("Sound") == "Off")
        {
            GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite = Themes[PlayerPrefs.GetInt("Themes")];
            PlayerPrefs.SetString("Sound", "On");
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite = OffTheme[PlayerPrefs.GetInt("Themes")];
            PlayerPrefs.SetString("Sound", "Off");
        }

    }
}
