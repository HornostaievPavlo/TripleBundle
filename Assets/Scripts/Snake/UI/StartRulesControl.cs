using UnityEngine;
using UnityEngine.UI;

public class StartRulesControl : MonoBehaviour
{
    [SerializeField] private PlayerController PlayerController;

    [SerializeField] private FoodSpawner FoodSpawner;

    [SerializeField] private Text rulesHeader;

    [SerializeField] private Text rulesText;

    public bool isRulesRead;

    private void Start()
    {
        PlayerController.forwardSpeed = 0.0f;

        isRulesRead = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rulesHeader.gameObject.SetActive(false);
            rulesText.gameObject.SetActive(false);

            isRulesRead = true;

            PlayerController.forwardSpeed = 0.1f;

            FoodSpawner.enabled = true;
        }
    }
}
