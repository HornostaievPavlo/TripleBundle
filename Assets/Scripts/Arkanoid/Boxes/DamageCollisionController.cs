using UnityEngine;

public class DamageCollisionController : MonoBehaviour
{
    private BoxGetDamage boxGetDamage;

    private void Awake()
    {
        boxGetDamage = GetComponent<BoxGetDamage>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boxGetDamage.GetDamage();
        }
    }
}
