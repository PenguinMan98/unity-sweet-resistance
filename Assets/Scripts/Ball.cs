using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] Vector2 paddleLaunchVector = new Vector2(2f, 8f);
    [SerializeField] AudioClip[] bounceSounds;
    [SerializeField] float randomFactor = 0.1f;

    // state
    Vector2 paddleToBallVector;
    bool ballLaunched = false;
    float launchVelocity;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ballLaunched)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = paddleLaunchVector;
            launchVelocity = paddleLaunchVector.magnitude;
            ballLaunched = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float modX = UnityEngine.Random.Range(myRigidBody2D.velocity.x - randomFactor, myRigidBody2D.velocity.x + randomFactor);
        float modY = UnityEngine.Random.Range(myRigidBody2D.velocity.y - randomFactor, myRigidBody2D.velocity.y + randomFactor);
        Vector2 velocityTweak = new Vector2(modX,modY);

        float currentVelocity = myRigidBody2D.velocity.magnitude;
        if(currentVelocity < launchVelocity)
        {
            //TODO: Speed the ball up
        }

        if (ballLaunched)
        {
            myAudioSource.PlayOneShot(bounceSounds[UnityEngine.Random.Range(0, bounceSounds.Length)]);
            myRigidBody2D.velocity = velocityTweak;
        }
    }
}
