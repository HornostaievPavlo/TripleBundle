using UnityEngine;

public class SnakePauseManager : MonoBehaviour
{
    private PlayerController PlayerController;

    [SerializeField] private GameObject[] pauseMenuItems;

    [SerializeField] private GameObject snake;

    public bool isGamePaused = false;

    void Start()
    {
        PlayerController = snake.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ContinueGame()
    {
        Time.timeScale = 1.0f;

        foreach (GameObject item in pauseMenuItems)
        {
            item.gameObject.SetActive(false);
        }

        float normalSpeed = 0.1f;
        float normalRotation = 2.0f;

        PlayerController.forwardSpeed = normalSpeed;
        PlayerController.rotationSpeed = normalRotation;
    }

    private void PauseGame()
    {
        Time.timeScale = 0.0f;

        foreach (GameObject item in pauseMenuItems)
        {
            item.gameObject.SetActive(true);
        }

        PlayerController.forwardSpeed = 0.0f;
        PlayerController.rotationSpeed = 0.0f;
    }
}
