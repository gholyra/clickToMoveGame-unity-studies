using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Vector3 minSpawnPosition;
    [SerializeField] private Vector3 maxSpawnPosition;

    private float elapsedTime;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnRate)
        {
            float randomX = Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
            float randomZ = Random.Range(minSpawnPosition.z, maxSpawnPosition.z);
            Vector3 spawnPosition = new Vector3(randomX, enemy.transform.position.y, randomZ);
            Instantiate(enemy, spawnPosition, enemy.transform.rotation);
            elapsedTime = 0f;
        }
    }
}
