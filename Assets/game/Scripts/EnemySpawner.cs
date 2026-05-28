using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private int maxActiveEnemies = 5;
    [SerializeField] private int enemiesPerWave = 5;
    [SerializeField] private float timeBetweenWaves = 3f;

    private int currentWave = 1;
    private int enemiesSpawnedThisWave;
    private int enemiesDefeatedThisWave;
    private bool waveInProgress;

    private int activeEnemyCount = 0;
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
        waveInProgress = true;

        if (maxActiveEnemies <= 0)
        {
            Debug.LogError("Max active enemies must be greater than zero.");
            maxActiveEnemies = 1;
        }

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
            if (activeEnemyCount >= maxActiveEnemies)
            {
                //Debug.Log("Maximum active enemies reached. Waiting to spawn.");
                spawnTimer = spawnInterval;
                return;
            }
            if (enemiesSpawnedThisWave >= enemiesPerWave)
            {
                return;
            }
            SpawnEnemy();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        if (playerIsDead) return;
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        activeEnemyCount++;
        enemiesSpawnedThisWave++;
    }
    void HandleDeath(Transform character)
    {
        if (character.CompareTag("Player"))
        {
            playerIsDead = true;
        }

        if (character.CompareTag("Enemy"))
        {
            activeEnemyCount--;

            if (activeEnemyCount < 0)
            {
                activeEnemyCount = 0;
            }

            enemiesDefeatedThisWave++;
            Debug.Log("Wave " + currentWave + " defeated enemies: " + enemiesDefeatedThisWave);
        }
    }
}
