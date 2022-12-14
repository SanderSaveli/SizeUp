using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private readonly float speed = 0.5f;
    private readonly float checkPos = -6.5f;
    public bool istap; //отвечает за определение включить,выключить кнопки
    private bool isGamrStart;
    public GameObject MusicB;
    public GameObject SoundB;
    public GameObject QuestionB;
    private Transform Tr;

    public Sprite[] Themes;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Themes[PlayerPrefs.GetInt("Themes")];
        Tr = GetComponent<Transform>();
        
    }
    private void Update()
    {
        isGamrStart = GameObject.Find("PlayButton").GetComponent<PlayButton>().gameStart;
        if (Tr.position.y != checkPos)
        {
            Tr.position += new Vector3(0, speed, 0f);

        }
        if (isGamrStart)
        {
            if (Tr.position.x <= 6f)
            {
                Tr.position += new Vector3(0.1f, 0, 0);

            }
        }
    }
    private void OnMouseDown()
    {
        transform.localScale += new Vector3(0.1f,0.1f,0);
    }

    private void OnMouseUp()
    {
        istap = !istap;
        transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        MusicB.gameObject.SetActive(true);
        SoundB.gameObject.SetActive(true);
        QuestionB.gameObject.SetActive(true);
    }
}
