﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject ball = collision.gameObject;
        if(ball.tag == "Ball")
        {
            Vector2 vel = ball.GetComponent<Rigidbody2D>().velocity;
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(vel.x, vel.y * -1);

        }
    }

}
