using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy prefab is not assigned in the inspector.");
            return;
        }

        Debug.Log("Spawning enemy at: " + transform.position);
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
