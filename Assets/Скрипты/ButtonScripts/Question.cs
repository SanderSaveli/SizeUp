using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    private Transform Tr;
    public GameObject question;
    public readonly float checkPos = -0.5f;
    public readonly float speed = 0.2f;
    private bool IsTap;
    public Sprite[] Themes;
    public GameObject Training;
    private void Start()
    {
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
        {
            Tr.position -= new Vector3(0, speed, 0f);
        }
        else if (Tr.position.y <= -6.5)
        {
            question.gameObject.SetActive(false);
        }
    }
    private void OnMouseUp()
    {
        Training.SetActive(true);
    }

}
