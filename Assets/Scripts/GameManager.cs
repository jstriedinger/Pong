using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float speed = 5f;
    public float paddleSpeed = 5f;
    [SerializeField] TextMeshProUGUI scoreTxtP1;
    [SerializeField] TextMeshProUGUI scoreTxtP2;
    [SerializeField] Player paddleP1;
    [SerializeField] Player paddleP2;

    int scoreP1 = 0;
    int scoreP2 = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        scoreTxtP1.text = scoreP1.ToString();
        scoreTxtP2.text = scoreP2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int points, bool toP1)
    {
        if (toP1)
        {
            scoreP1 += points;
            scoreTxtP1.text = scoreP1.ToString();
            paddleP2.assignBall();

        }
        else
        {
            scoreP2 += points;
            scoreTxtP2.text = scoreP2.ToString();
            paddleP1.assignBall();
        }
    }
}
