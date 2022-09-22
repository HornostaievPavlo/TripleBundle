using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [HideInInspector] public Rigidbody ball;

    private Vector3 ballStartForce;

    public bool isBallOnPlatform;// public for UIManager

    void Start()
    {
        ball = GetComponent<Rigidbody>();

        InitializeForce();

        isBallOnPlatform = true;
    }

    void Update()
    {
        LaunchBall();
    }

    private void InitializeForce()
    {
        float startForceRightMultiplier = Random.Range(15, 30);

        float startForceUpMultiplier = Random.Range(20, 30);

        ballStartForce = new Vector3(startForceRightMultiplier, startForceUpMultiplier, 0);
    }

    private void LaunchBall()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isBallOnPlatform)
            {
                ball.AddForce(ballStartForce);
                isBallOnPlatform = false;
            }
        }
    }
}