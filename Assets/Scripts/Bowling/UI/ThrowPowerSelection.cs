using UnityEngine;

public class ThrowPowerSelection : MonoBehaviour
{
    [SerializeField] private BallForwardMovement ballForwardMovement;

    private bool isBoundaryReached = false;

    private float leftBoundary = -0.73f;

    private float rightBoundary = 0.73f;

    private float sideSpeed = 5.0f;

    void Update()
    {
        SideMovement();

        ForceSelection();
    }

    private void SideMovement()
    {
        if (!isBoundaryReached)
        {
            transform.Translate(Vector3.back * sideSpeed * Time.deltaTime);
        }

        if (transform.position.x < leftBoundary)
        {
            isBoundaryReached = false;
        }

        if (isBoundaryReached)
        {
            transform.Translate(Vector3.forward * sideSpeed * Time.deltaTime);
        }

        if (transform.position.x > rightBoundary)
        {
            isBoundaryReached = true;
        }
    }

    private void ForceSelection()
    {
        if (transform.position.x < -0.5f) // very low
        {
            ballForwardMovement.ballForwardSpeed = 400;
        }

        if (transform.position.x < 0.0f) // low 
        {
            ballForwardMovement.ballForwardSpeed = 500;
        }

        if (transform.position.x > 0.0f) // middle 
        {
            ballForwardMovement.ballForwardSpeed = 750;
        }

        if (transform.position.x > 0.5f) // high
        {
            ballForwardMovement.ballForwardSpeed = 1000;
        }
    }
}
