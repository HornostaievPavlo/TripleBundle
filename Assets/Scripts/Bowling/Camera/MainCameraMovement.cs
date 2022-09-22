using UnityEngine;

public class MainCameraMovement : MonoBehaviour
{
    [SerializeField] private BallForwardMovement ballForwardMovement;

    private float cameraSpeed;

    void FixedUpdate()
    {
        CheckBallSpeed();

        MoveCamera();
    }

    private void MoveCamera()
    {
        transform.Translate(0, 0, cameraSpeed * Time.deltaTime);
    }

    private void CheckBallSpeed()
    {
        switch (ballForwardMovement.ballForwardSpeed)
        {
            case 400.0f:
                cameraSpeed = 3;
                break;

            case 500.0f:
                cameraSpeed = 9;
                break;

            case 750.0f:
                cameraSpeed = 10;
                break;

            case 1000.0f:
                cameraSpeed = 12;
                break;
        }
    }
}