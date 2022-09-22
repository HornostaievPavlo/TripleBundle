using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameLosed = false;

    private float delayToRestart = 2;

    public void GameOver()
    {
        if (gameLosed == false)
        {
            gameLosed = true;
            Invoke(nameof(RestartLevel), delayToRestart);
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
