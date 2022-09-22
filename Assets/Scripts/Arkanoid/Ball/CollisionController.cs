using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private Rigidbody[] boxes;

    [HideInInspector] public int bricksLeftNumber; // public for UIManager

    void Start()
    {
        bricksLeftNumber = boxes.Length * 2;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            bricksLeftNumber -= 1;
        }
    }
}