using UnityEngine;

public class BallForwardMovement : MonoBehaviour
{
    private Rigidbody ball;

    public float ballForwardSpeed;

    private void Start()
    {
        ball = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ball.AddForce(0, 0, ballForwardSpeed * Time.deltaTime, ForceMode.Acceleration);
    }
}
