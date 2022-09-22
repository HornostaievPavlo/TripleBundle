using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private PlayerController PlayerController;

    private SelfDestruction SelfDestruction;

    [SerializeField] private GameObject snake;

    [SerializeField] private Text outOfField;

    [SerializeField] private Text gameOver;

    [SerializeField] private Text scoreNumber;

    [SerializeField] private Text scoreText;

    [SerializeField] private Animator scoreNumberAnimator;

    void Start()
    {
        PlayerController = snake.GetComponent<PlayerController>();

        SelfDestruction = snake.GetComponent<SelfDestruction>();
    }

    void Update()
    {
        CheckSnakeInsideGameField();

        CheckSnakeEatItself();

        TrackScore();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            scoreText.gameObject.SetActive(true);
            scoreNumber.gameObject.SetActive(true);
        }
    }

    private void CheckSnakeInsideGameField()
    {
        if (!PlayerController.isInGameField)
        {
            outOfField.gameObject.SetActive(true);
        }
        else
        {
            outOfField.gameObject.SetActive(false);
        }
    }

    private void CheckSnakeEatItself()
    {
        if (!SelfDestruction.isSnakeDeath)
        {
            gameOver.gameObject.SetActive(false);
        }
        else
        {
            gameOver.gameObject.SetActive(true);
        }
    }

    private void TrackScore()
    {
        scoreNumber.text = PlayerController.score.ToString();

        if (SelfDestruction.isSnakeDeath == true)
        {
            scoreNumberAnimator.enabled = true;
        }
    }
}