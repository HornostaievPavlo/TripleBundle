using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinHit : MonoBehaviour
{
    private BallForwardMovement ballForwardMovement;

    [SerializeField] private MainCameraMovement cameraMovement;

    public bool isPinHit = false;

    private void Start()
    {
        ballForwardMovement = GetComponent<BallForwardMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pin")
        {
            isPinHit = true;

            ballForwardMovement.enabled = false;
            cameraMovement.enabled = false;

            StartCoroutine(ReloadScene());
        }
    }

    private IEnumerator ReloadScene()
    {
        int secondsToReloadScene = 10;
        yield return new WaitForSeconds(secondsToReloadScene);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
