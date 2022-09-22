using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;

    [SerializeField] private GameObject[] MenuItems;

    [SerializeField] private Text startText;
    [SerializeField] private Text loseText;
    [SerializeField] private Text winText;

    private BallController BallController;

    private CollisionController CollisionController;

    void Start()
    {
        BallController = ball.GetComponent<BallController>();

        CollisionController = ball.GetComponent<CollisionController>();

        startText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startText.gameObject.SetActive(false);
        }

        if (CollisionController.bricksLeftNumber == 0)
        {
            winText.gameObject.SetActive(true);
            BallController.ball.isKinematic = true;

            foreach (GameObject item in MenuItems)
            {
                item.gameObject.SetActive(true);
            }
        }

        if (BallController.ball.position.y < -5) // lose 
        {
            loseText.gameObject.SetActive(true);
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}