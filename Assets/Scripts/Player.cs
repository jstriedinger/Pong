﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] bool isPlayerone = false;

    GameManager gameManager;
    float speed = 5f;
    float paddleSpeed = 5f;
    bool hasBall = false;
    GameObject gameBall;
    float topLimit;
    float bottomLimit;

    // Start is called before the first frame update
    void Start()
    {
        topLimit = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).y;
        bottomLimit = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
        gameManager = FindObjectOfType<GameManager>();
        speed = gameManager.speed;
        paddleSpeed = gameManager.paddleSpeed;
        if (isPlayerone)
            hasBall = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(hasBall)
        {
            if(isPlayerone)
                gameBall.transform.position = transform.position + new Vector3(1f, 0,0);
            else
                gameBall.transform.position = transform.position + new Vector3(-1f, 0, 0);
        }
        if(Input.GetKey(KeyCode.Space) && hasBall)
        {
            hasBall = false;
            if(isPlayerone)
                gameBall.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.fixedDeltaTime,speed * Time.fixedDeltaTime);
            else
                gameBall.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed * Time.fixedDeltaTime, -speed * Time.fixedDeltaTime);
        }

        if(isPlayerone)
        {
            if (transform.position.y  < topLimit - 1.5f)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.Translate(transform.up * paddleSpeed * Time.deltaTime);
                }
            }
            if (transform.position.y > bottomLimit +1.5f)
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Translate(transform.up * paddleSpeed * Time.deltaTime * -1);
                }
            }
            
        }
        else
        {
            if (transform.position.y < topLimit - 1.5f)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(transform.up * paddleSpeed * Time.deltaTime);
                }
            }
            if (transform.position.y > bottomLimit + 1.5f)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(transform.up * paddleSpeed * Time.deltaTime * -1);
                }
            }
        }
    }

    public void assignBall(GameObject _ball)
    {
        gameBall = Instantiate(_ball);
        hasBall = true;
    }
}
