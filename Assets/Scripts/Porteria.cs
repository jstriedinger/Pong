using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Porteria : MonoBehaviour
{
    [SerializeField] bool isPlayerOne = false;

    int score = 0;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
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
            gameManager.addScore(1, !isPlayerOne);
        }
    }
}
