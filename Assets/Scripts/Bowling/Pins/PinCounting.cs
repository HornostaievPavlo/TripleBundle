using System.Collections;
using UnityEngine;

public class PinCounting : MonoBehaviour
{
    [SerializeField] private PinHit pinHit;

    [SerializeField] private GameObject[] pins;

    public int score = 0;

    private void Update()
    {
        if (pinHit.isPinHit == true)
        {
            StartCoroutine(StartCount());
        }
    }

    private IEnumerator StartCount()
    {
        int secondsTillDeleting = 5;
        yield return new WaitForSeconds(secondsTillDeleting);

        CountPinFall();
    }

    private void CountPinFall()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            if (pins[i].transform.eulerAngles.z > 10 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                score++;

                pins[i].SetActive(false);
            }
        }
    }
}

