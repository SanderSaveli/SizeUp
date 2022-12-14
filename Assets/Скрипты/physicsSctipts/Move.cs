using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.5f;
    public Rigidbody2D rb;
    
        
    void Start()
    {
        int v = Random.Range(1, 4);
        switch (v)
        {
            case 1:
                rb.AddForce(new Vector2(Random.Range(0.5f, 1f) * speed, Random.Range(0.5f, 1f) * speed), ForceMode2D.Impulse);
                break;
            case 2:
                rb.AddForce(new Vector2(Random.Range(-0.5f, -1f) * speed, Random.Range(0.5f, 1f) * speed), ForceMode2D.Impulse);
                break;
            case 3:
                rb.AddForce(new Vector2(Random.Range(0.5f, 1f) * speed, Random.Range(-0.5f, -1f) * speed), ForceMode2D.Impulse);
                break;
            case 4:
                rb.AddForce(new Vector2(Random.Range(-0.5f, -1f) * speed, Random.Range(-0.5f, -1f) * speed), ForceMode2D.Impulse);
                break;
        }
             
           
    }
    
}




