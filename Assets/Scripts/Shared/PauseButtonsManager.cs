using UnityEngine;

public class PauseButtonsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] pauseMenuItems;

    public bool isGamePaused = false;

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
        isGamePaused = false;

        Time.timeScale = 1.0f;

        foreach (GameObject item in pauseMenuItems)
        {
            item.gameObject.SetActive(false);
        }
    }

    private void PauseGame()
    {
        isGamePaused = true;

        Time.timeScale = 0.0f;

        foreach (GameObject item in pauseMenuItems)
        {
            item.gameObject.SetActive(true);
        }
    }
}