using UnityEngine;

public class Launcher : MonoBehaviour
{
    private BallForwardMovement ballForwardMovement;

    private BallStartControl ballStartControl;

    private Launcher launcher;

    [SerializeField] private MainCameraMovement cameraMovement;

    private void Start()
    {
        ballForwardMovement = GetComponent<BallForwardMovement>();
        ballStartControl = GetComponent<BallStartControl>();
        launcher = GetComponent<Launcher>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ballStartControl.enabled = false;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            ballForwardMovement.enabled = true;

            cameraMovement.enabled = true;

            launcher.enabled = false;
        }
    }
}
