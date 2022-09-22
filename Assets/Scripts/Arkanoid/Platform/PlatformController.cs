using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private Vector3 platformPosition;

    private void Awake()
    {
        platformPosition = gameObject.transform.position;
    }

    void Update()
    {
        HorizontalMovement();

        BoundaryCheck();
    }

    private void HorizontalMovement()
    {
        float horizontalMovementSpeed = 15.0f;

        float horizontalMovement = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * horizontalMovement * horizontalMovementSpeed);
    }

    private void BoundaryCheck()
    {
        float boundary = 7;

        if (transform.position.x > boundary)
        {
            transform.position = new Vector3(boundary, platformPosition.y, platformPosition.z);
        }

        if (transform.position.x < -boundary)
        {
            transform.position = new Vector3(-boundary, platformPosition.y, platformPosition.z);
        }
    }
}