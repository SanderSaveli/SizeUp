using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using UnityEngine;

public class Отражение : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 LastVelocity;
    public float Speed = 4.25f;
    private bool IsGameStart;
    private uint count = 0; //отсчитывает фазу динамической сложности
    public float timer=30f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        IsGameStart = GameObject.Find("PlayButton").GetComponent<PlayButton>().gameStart;
        LastVelocity = rb.velocity;
        if (IsGameStart && count < 6) //логика для постепеннного увеличения скорости
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Speed+=0.25f;
                timer = 5;
                count += 1;
            }
        }
        if (!IsGameStart) // возврат к начальным значениям после окончания игры
        {
            count = 0;
            timer = 30f;
            Speed = 4.25f;
        }
    }
    
   
    private void OnCollisionEnter2D(Collision2D coll)
    {
        var speed = Speed; //LastVelocity.magnitude;
        var direction = Vector2.Reflect(LastVelocity.normalized, coll.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }




}
