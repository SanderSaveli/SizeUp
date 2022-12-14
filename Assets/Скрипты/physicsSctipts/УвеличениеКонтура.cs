using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class УвеличениеКонтура : MonoBehaviour
{
    private Transform Tr;
    private bool isGameStart;
    private void Start()
    {
        Tr = GetComponent<Transform>();

    }
    void Update()
    {
        isGameStart = GameObject.Find("PlayButton").GetComponent<PlayButton>().gameStart;

        if (isGameStart && Tr.localScale.y < 1.2f)
        {
            transform.localScale += new Vector3(0.005f, 0.005f, 0);
        }
        else
        {
            if (!isGameStart && Tr.localScale.y > 1.1f)
            {
                transform.localScale -= new Vector3(0.005f, 0.005f, 0);
            }
        }

    }
}
