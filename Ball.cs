using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Referencias Ball
    private Rigidbody2D ballRb;
    [SerializeField] private Vector2 initialVelocity;
    [SerializeField] private float velocityMultiplier;
    private bool isBallMoving;
    
    //Referencias Sonidos
    public AudioSource audioSource;
    public AudioClip playerSound, brickSound, loseTrigger, wallSound;
   


    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isBallMoving)
        {
            Launch();
        }
    }

    private void Launch()
    {
        transform.parent = null;
        ballRb.velocity = initialVelocity;
        isBallMoving = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            audioSource.clip = brickSound;
            audioSource.Play();
            ballRb.velocity *= velocityMultiplier;
            GameManager.Instance.BlockDestroyed();
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            audioSource.clip = playerSound;
            audioSource.Play();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            audioSource.clip = loseTrigger;
            audioSource.Play();
        }

        if (collision.gameObject.CompareTag("DeadZone"))
        {
            audioSource.clip = loseTrigger;
            audioSource.Play();
        }

        VelocityFix();
    }

    private void VelocityFix()
    {
        float velocityDelta = 0.5f;
        float minVelocity = 0.2f;
        
        if(Mathf.Abs(ballRb.velocity.x)<minVelocity)
        {
            velocityDelta = Random.value < 0.5f ? velocityDelta : -velocityDelta;
            ballRb.velocity += new Vector2(velocityDelta, 0f);
        }

        if(Mathf.Abs(ballRb.velocity.y) <minVelocity)
        {
            velocityDelta = Random.value < 0.5f ? velocityDelta : -velocityDelta;
            ballRb.velocity += new Vector2(velocityDelta, 0f);
        }
    }

}
