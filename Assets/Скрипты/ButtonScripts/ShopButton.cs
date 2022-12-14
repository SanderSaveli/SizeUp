using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShopButton : MonoBehaviour
{
    private float speed = 0.5f;
    private float checkPos = -6.5f;
    private bool isGameStart;
    private Transform Tr;
    public Sprite[] Themes;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Themes[PlayerPrefs.GetInt("Themes")];
        Tr = GetComponent<Transform>();
    }
    private void Update()
    {
        isGameStart = GameObject.Find("PlayButton").GetComponent<PlayButton>().gameStart;
        if (isGameStart)
        {
            if (Tr.position.x >= -6f)
            {
                Tr.position += new Vector3(-0.1f, 0, 0);

            }
        }
        
        if (Tr.position.y != checkPos)
        {
            Tr.position += new Vector3(0, speed, 0f);

        }

        
    }
    private void OnMouseDown()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0);
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        SceneManager.LoadScene("Shop");

    }
}
