using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip hitSound;

    [SerializeField] private AudioClip explosionSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayHitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }

    public void PlayExplosionSound()
    {
        audioSource.PlayOneShot(explosionSound);
    }
}
