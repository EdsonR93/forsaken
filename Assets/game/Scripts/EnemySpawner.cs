using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 5f;
    private float spawnTimer;
    private bool playerIsDead;

    void OnEnable()
    {
        CombatEvents.OnDeath += HandleDeath;
    }

    void OnDisable()
    {
        CombatEvents.OnDeath -= HandleDeath;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = spawnInterval;
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj == null)
        {
            Debug.LogError("Player object not found in the scene.");
            enabled = false;
            return;
        }
        PlayerHealth playerHealth = playerObj.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            if (playerIsDead = playerHealth.IsDead)
            {
                Debug.Log("Player is already dead at spawner start. No enemies will spawn.");
                return;
            }
        }
        else
        {
            Debug.LogWarning("PlayerHealth component not found on Player.");
        }


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
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            SpawnEnemy();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        if (playerIsDead) return;
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
    void HandleDeath(Transform character)
    {
        if (character.CompareTag("Player"))
        {
            playerIsDead = true;
        }
    }
}
