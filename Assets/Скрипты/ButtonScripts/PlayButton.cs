using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    
    public bool gameStart=false;
    private float speed = -0.5f;
    private float startPos = 0;
    
    private bool doJump;
    private Transform Tr;
    public Sprite[] Themes;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Themes[PlayerPrefs.GetInt("Themes")];
        Tr = GetComponent<Transform>();
    }

    private void Update()
    {
        if (gameObject.tag=="PlayButton")
        {
            if (Tr.position.x != startPos)
            {
                Tr.position += new Vector3(speed, 0, 0);

            }
            if (doJump)
            {
                if (Tr.position.y <= -2f)
                {
                    Tr.position += new Vector3(0, 0.15f, 0);
                }
                else
                {
                    doJump = false;
                }

            }
            if (gameStart && !doJump)
            {
                if (Tr.position.y >= -10f)
                {
                    Tr.position -= new Vector3(0, 0.17f, 0);

                }
            }
            if (gameStart)
            {
                gameStart = !(GameObject.Find("Player").GetComponent<Смерть>().Death); // это отключает GS после смерти
            }

        }
    }
    private void OnMouseDown()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0);
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        gameStart = true;
        if (PlayerPrefs.GetString("Sound")=="On")
            GetComponent<AudioSource>().Play();
        if(Tr.position.y>-5f)
            doJump = true;
    
    }
}
