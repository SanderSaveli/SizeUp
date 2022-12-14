using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackButton : MonoBehaviour
{
    public Sprite[] Themes;

    private void Start()
    {
        if (tag!= "Shop")
        {
            GetComponent<SpriteRenderer>().sprite = Themes[PlayerPrefs.GetInt("Themes")];
        }
    }
    private void OnMouseDown()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0);
    }

    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        SceneManager.LoadScene("MainMenu");
    }

}
