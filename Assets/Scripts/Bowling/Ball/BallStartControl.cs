using UnityEngine;

public class BallStartControl : MonoBehaviour
{
    private float leftBoundary = 2.5f;

    private float rightBoundary = 1.5f;

    private bool isBoundaryReached = false;

    private float sideSpeed = 9.0f;

    void Update()
    {
        SideMovement();
    }

    private void SideMovement()
    {
        if (!isBoundaryReached)
        {
            transform.Translate(Vector3.left * sideSpeed * Time.deltaTime);
        }

        if (transform.position.x > rightBoundary)
        {
            isBoundaryReached = true;
        }

        if (isBoundaryReached)
        {
            transform.Translate(Vector3.right * sideSpeed * Time.deltaTime);
        }

        if (transform.position.x < -leftBoundary)
        {
            isBoundaryReached = false;
        }
    }
}