using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    private PlayerController PlayerController;

    [SerializeField] private GameObject snake;

    [SerializeField] private GameObject[] foodPrefabs;

    private void Start()
    {
        PlayerController = snake.GetComponent<PlayerController>();

        InvokeRepeating("SpawnFood", 0.1f, 5);
    }

    private void SpawnFood()
    {
        float spawnPositionX = Random.Range(-17, 17);
        float spawnPositionY = (0.1f);
        float spawnPositionZ = Random.Range(3, 37);

        int randomPrefab = Random.Range(0, foodPrefabs.Length);

        Vector3 spawnPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);

        Instantiate(foodPrefabs[randomPrefab], spawnPosition, foodPrefabs[randomPrefab].transform.rotation);
    }
}
