using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BowlingUI : MonoBehaviour
{
    [SerializeField] private PinCounting pinCounting;

    [SerializeField] private PinHit pinHit;

    [SerializeField] private GameObject[] rulesTexts;

    [SerializeField] private Text score;

    [SerializeField] private Text scoreText;

    [SerializeField] private Text strikeText;

    void Update()
    {
        ShowUIOnHit();

        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach (GameObject item in rulesTexts)
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    private void ShowUIOnHit()
    {
        if (pinHit.isPinHit == true)
        {
            StartCoroutine(ShowScore());

            score.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);

            CheckForStrikeHit();
        }
    }

    private void CheckForStrikeHit()
    {
        if (pinCounting.score == 10)
        {
            strikeText.gameObject.SetActive(true);
        }
    }

    private IEnumerator ShowScore()
    {
        yield return new WaitForSeconds(5);
        score.text = pinCounting.score.ToString();
    }
}
