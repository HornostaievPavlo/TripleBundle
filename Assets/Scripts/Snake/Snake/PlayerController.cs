using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private List<Transform> SnakeParts;

    [SerializeField] private GameObject partPrefab;

    private Audio Audio;

    private Transform transform;

    public float rotationSpeed = 2.0f;

    public float forwardSpeed;

    public bool isInGameField;

    public bool isFoodHit;

    public int score;

    private void Awake()
    {
        Audio = GetComponent<Audio>();

        transform = GetComponent<Transform>();

        score = 0;
    }

    private void FixedUpdate()
    {
        Move(transform.position + transform.forward * forwardSpeed); // auto forward movement

        Rotate();
    }

    private void Move(Vector3 newPosition)
    {
        float PartsSpace = 1.25f;

        transform.position = newPosition; // current place

        float distanceOfOnePart = PartsSpace * PartsSpace; // length equal to two parts of a snake 

        Vector3 previousPartPosition = transform.position; // beginning from the head

        foreach (var part in SnakeParts)
        {
            if ((part.position - previousPartPosition).sqrMagnitude > distanceOfOnePart)
            {//if (pos of this - pos of prev)squareRoot cause should is power2  > should be as one part
                var currentPosition = part.position;

                part.position = previousPartPosition;

                previousPartPosition = currentPosition;
            }
            else
            {
                break;
            }
        }
    }

    private void Rotate()
    {
        float rotationAngle = Input.GetAxis("Horizontal") * rotationSpeed;

        Vector3 rotationVector = new Vector3(0, rotationAngle, 0);

        transform.Rotate(rotationVector);
    }

    private void AddPart()
    {
        Vector3 spawnPosition = new Vector3(0, 0, -60);

        var newPart = Instantiate(partPrefab, spawnPosition, partPrefab.transform.rotation);

        SnakeParts.Add(newPart.transform);
    }

    private void AddPartsOutOfGameField()
    {
        int additionalPartPunishment = 10;

        for (int i = 0; i < additionalPartPunishment; i++)
        {
            AddPart();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food") // eating changes
        {
            Audio.PlayHitSound();

            isFoodHit = true;

            score++;

            Destroy(collision.gameObject);

            forwardSpeed *= 1.01f;

            rotationSpeed *= 1.01f;

            AddPart();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isFoodHit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameField")
        {
            isInGameField = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInGameField = false;

        AddPartsOutOfGameField();
    }
}
