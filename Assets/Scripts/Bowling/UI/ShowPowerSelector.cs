using UnityEngine;

public class ShowPowerSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] forceSelector;

    void Update()
    {
        SelectorControl();
    }

    private void SelectorControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowSelector();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            HideSelector();
        }
    }

    private void ShowSelector()
    {
        foreach (GameObject item in forceSelector)
        {
            item.gameObject.SetActive(true);
        }
    }

    private void HideSelector()
    {
        foreach (GameObject item in forceSelector)
        {
            item.gameObject.SetActive(false);
        }
    }
}
