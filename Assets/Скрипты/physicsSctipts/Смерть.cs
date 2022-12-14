using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Смерть : MonoBehaviour
{
    
    public GameObject Player, ReturnButton,Backbutton;
    public bool Death;
    private bool An;
    private void Update()
    {
        An = GameObject.Find("TouchCount").GetComponent<tap>().animete;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (An)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
                Death = true;
                
            }
        }
    }
    private void FixedUpdate()
    {
        if (Death)
        {
            ReturnButton.gameObject.SetActive(true);
            Backbutton.gameObject.SetActive(true);
            Player.gameObject.SetActive(false);
        }
    }

}    
