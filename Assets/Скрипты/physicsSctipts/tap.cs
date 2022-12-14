using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class tap : MonoBehaviour
{
    public GameObject player;
    private bool isGameStart;
    public bool animete;
    private readonly float compression = 1.5f; // эта переменная отвечает за скорость сжатия
    private readonly float stretching = 0.5f;  // за скорость увеличения
    public GameObject Training;

    void FixedUpdate()
    {
        isGameStart= GameObject.Find("PlayButton").GetComponent<PlayButton>().gameStart;
        if (isGameStart)
        {

            if (animete)    // присваиваем animate буливое значение в зависимости от нажатия на экран и при true увеличиваем размер
            {

                player.transform.localScale += new Vector3(stretching * Time.deltaTime, stretching * Time.deltaTime, 0f);
            }
            else
            {
                if (player.transform.localScale.y > 0.5f)   // плавное возвращение к нормальному значению
                {
                    player.transform.localScale -= new Vector3(compression * Time.deltaTime, compression * Time.deltaTime, 0f);
                    if (player.transform.localScale.y < 0.5f)
                    {
                        // player.transform.localPosition -= new Vector3(compression * Time.deltaTime, compression * Time.deltaTime, 0f);
                        player.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                    }
                }

            }
        }
    }

    void OnMouseDown ()
    {
        if (isGameStart)
        {
            animete = true;
        }
    }
    void OnMouseUp()
    {
        if (isGameStart)
        {

            animete = false;
        }
        if (Training.gameObject.activeSelf == true)
        {
            Training.gameObject.SetActive(false);
        }
    }
        
    
}
