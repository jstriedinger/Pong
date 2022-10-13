using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] AudioClip wallBounceSFX;
    [SerializeField] AudioClip goalSFX;

    Rigidbody2D myBody;

    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objeto = collision.gameObject;
        if (objeto.tag == "Wall")
        {
            AudioSource.PlayClipAtPoint(wallBounceSFX, Camera.main.transform.position);
            Vector2 vel = myBody.velocity;
            myBody.velocity = new Vector2(vel.x, vel.y * -1);

        }
        else if(objeto.tag == "Goal")
        {
            AudioSource.PlayClipAtPoint(goalSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
        else if(objeto.tag == "Paddle")
        {
            AudioSource.PlayClipAtPoint(wallBounceSFX, Camera.main.transform.position);
            Vector2 vel = myBody.velocity;
            myBody.velocity = new Vector2(vel.x * -1, vel.y);
        }
    }
}
