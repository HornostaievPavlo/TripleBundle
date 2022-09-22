using UnityEngine;

public class BoxGetDamage : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private Audio audio;

    [SerializeField] private Material damaged;

    [SerializeField] private ParticleSystem hitParticle;

    private int boxLife = 2;

    private void Awake()
    {
        audio = GetComponent<Audio>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void GetDamage()
    {
        boxLife--;

        if (boxLife == 0)
        {
            meshRenderer.enabled = false;

            GetComponent<BoxCollider>().enabled = false;

            hitParticle.Play();

            audio.PlayExplosionSound();
        }
        else
        {
            meshRenderer.material = damaged;

            audio.PlayHitSound();
        }
    }
}
