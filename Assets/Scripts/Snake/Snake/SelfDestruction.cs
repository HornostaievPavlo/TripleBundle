using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelfDestruction : MonoBehaviour
{
    private PlayerController PlayerController;    

    private Audio Audio;

    [SerializeField] private ParticleSystem explosion;

    public bool isSnakeDeath = false;

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
        Audio = GetComponent<Audio>();
    }

    private void Update()
    {
        CheckSnakeHitItself();

        CheckPositionInsideScreen();
    }

    private void CheckPositionInsideScreen()
    {
        if(transform.position.z > 60 || transform.position.z < -8 ||
           transform.position.x > 45 || transform.position.x < -50)
        {
            isSnakeDeath = true;
        }
    }

    private void CheckSnakeHitItself()
    {
        if (isSnakeDeath)
        {
            explosion.Play();

            Audio.PlayExplosionSound();

            StartCoroutine(GameOver());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Snake")
        {
            PlayerController.forwardSpeed = 0.0f;

            PlayerController.rotationSpeed = 0.0f;

            isSnakeDeath = true;
        }
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
