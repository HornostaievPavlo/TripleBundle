using UnityEngine;

public class SideCamerasAnimations : MonoBehaviour
{
    [SerializeField] private PinHit pinHit;

    [SerializeField] private GameObject backViewCamera;
    [SerializeField] private GameObject leftViewCamera;

    private Animator _leftCameraAnimator;

    private Animator _backCameraAnimator;

    private void Start()
    {
        _backCameraAnimator = backViewCamera.GetComponent<Animator>();

        _leftCameraAnimator = leftViewCamera.GetComponent<Animator>();
    }

    void Update()
    {
        if (pinHit.isPinHit == true)
        {
            _leftCameraAnimator.enabled = true;
            _backCameraAnimator.enabled = true;
        }
    }
}
