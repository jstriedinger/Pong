using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] bool isPlayerone = false;
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject ball;

    bool gameStarted = false;
    float topLimit;
    float bottomLimit;

    // Start is called before the first frame update
    void Start()
    {
        topLimit = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).y;
        bottomLimit = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;

    }

    // Update is called once per frame
    void Update()
    {
        if(!gameStarted && isPlayerone)
        {
            ball.transform.position = transform.position + new Vector3(1f, 0,0);
        }
        if(Input.GetKey(KeyCode.Space) && !gameStarted && isPlayerone)
        {
            gameStarted = true;
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(8f, 8f);
        }

        if(isPlayerone)
        {
            if (transform.position.y  < topLimit - 1f)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.Translate(transform.up * speed * Time.deltaTime);
                }
            }
            if (transform.position.y > bottomLimit +1f)
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.Translate(transform.up * speed * Time.deltaTime * -1);
                }
            }
            
        }
        else
        {
            if (transform.position.y < topLimit - 1f)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(transform.up * speed * Time.deltaTime);
                }
            }
            if (transform.position.y > bottomLimit + 1f)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(transform.up * speed * Time.deltaTime * -1);
                }
            }
        }
    }
}
