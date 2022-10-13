using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float speed = 5f;
    public float paddleSpeed = 5f;
    public int maxScore = 5;
    [SerializeField] TextMeshProUGUI scoreTxtP1;
    [SerializeField] TextMeshProUGUI scoreTxtP2;
    [SerializeField] Player paddleP1;
    [SerializeField] Player paddleP2;
    [SerializeField] GameObject gameBall;
    [SerializeField] GameObject gameover;
    [SerializeField] TextMeshProUGUI timerCountdown;
    [SerializeField] GameObject timerImage;
    [SerializeField] TextMeshProUGUI winnerTxt;
    [SerializeField] AudioClip countdownSFX;

    int scoreP1 = 0;
    int scoreP2 = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        scoreTxtP1.text = scoreP1.ToString();
        scoreTxtP2.text = scoreP2.ToString();
        paddleP1.assignBall(gameBall);
        gameover.SetActive(false);

        //timer
        StartCoroutine(Countdown());

    }

    private IEnumerator Countdown()
    {
        timerCountdown.gameObject.SetActive(true);
        int counter = 3;
        AudioSource.PlayClipAtPoint(countdownSFX, Camera.main.transform.position);
        while (counter > 0)
        {
            timerCountdown.text = counter.ToString();
            yield return new WaitForSeconds(0.85f);
            counter--;
        }
        timerCountdown.gameObject.SetActive(false);
        timerImage.SetActive(true);
        yield return new WaitForSeconds(1);
        timerImage.SetActive(false);

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
            
            if(scoreP1 >= maxScore)
            {
                winnerTxt.text = "Player 1 Wins!";
                Time.timeScale = 0;
                gameover.SetActive(true);
            }
            else
                paddleP2.assignBall(gameBall);
        }
        else
        {
            scoreP2 += points;
            scoreTxtP2.text = scoreP2.ToString();
            if (scoreP2 >= maxScore)
            {
                winnerTxt.text = "Player 2 Wins!";
                Time.timeScale = 0;
                gameover.SetActive(true);
            }
            else
                paddleP1.assignBall(gameBall);
        }
        
    }
}
