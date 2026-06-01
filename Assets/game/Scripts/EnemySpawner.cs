using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private int maxActiveEnemies = 5;
    [SerializeField] private int enemiesPerWave = 5;
    [SerializeField] private int enemiesAddedPerWave = 1;
    [SerializeField] private float timeBetweenWaves = 3f;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private int bossWaveInterval = 5;
    [SerializeField] private float healthScalingPerWave = 0.15f;
    [SerializeField] private float damageScalingPerWave = 0.10f;

    bool bossSpawnedThisWave;
    private int currentWave = 1;
    private int enemiesSpawnedThisWave;
    private int enemiesDefeatedThisWave;
    private bool waveInProgress;
    private float waveDelayTimer;
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
            playerIsDead = playerHealth.IsDead;

            if (playerIsDead)
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

        if (bossWaveInterval > 0 && bossPrefab == null)
        {
            Debug.LogWarning("Boss prefab is not assigned. Boss waves will not spawn bosses.");
        }

        if (spawnInterval <= 0) spawnInterval = 1f;
        if (enemiesPerWave <= 0) enemiesPerWave = 1;
        if (timeBetweenWaves < 0) timeBetweenWaves = 0f;
        if (healthScalingPerWave < 0) healthScalingPerWave = 0;
        if (damageScalingPerWave < 0) damageScalingPerWave = 0;


        Debug.Log("Spawning enemy at: " + transform.position);
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (!waveInProgress)
        {
            waveDelayTimer -= Time.deltaTime;

            if (waveDelayTimer <= 0)
            {
                StartNextWave();
            }

            return;
        }
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            if (activeEnemyCount >= maxActiveEnemies)
            {
                //Debug.Log("Maximum active enemies reached. Waiting to spawn.");
                spawnTimer = spawnInterval;
                return;
            }
            if (enemiesSpawnedThisWave >= GetEnemiesForCurrentWave())
            {
                return;
            }
            if (IsBossWave() && !bossSpawnedThisWave && enemiesSpawnedThisWave == GetEnemiesForCurrentWave() - 1)
            {
                SpawnBoss();
            }
            else
            {
                SpawnEnemy();
            }

            spawnTimer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        if (playerIsDead) return;
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
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
            //Debug.Log("Wave " + currentWave + " defeated enemies: " + enemiesDefeatedThisWave);
            CheckWaveComplete();
        }
    }

    void CheckWaveComplete()
    {
        if (!waveInProgress) return;

        if (enemiesDefeatedThisWave >= GetEnemiesForCurrentWave())
        {
            waveInProgress = false;
            waveDelayTimer = timeBetweenWaves;

            Debug.Log("Wave " + currentWave + " complete. Next wave starts soon.");
        }
    }
    void StartNextWave()
    {
        currentWave++;
        enemiesSpawnedThisWave = 0;
        enemiesDefeatedThisWave = 0;
        bossSpawnedThisWave = false;

        if (IsBossWave())
        {
            Debug.Log("Boss wave started: Wave " + currentWave);
        }
        else
        {
            Debug.Log("Starting Wave " + currentWave);
        }

        waveInProgress = true;
    }
    int GetEnemiesForCurrentWave()
    {
        return enemiesPerWave + ((currentWave - 1) * enemiesAddedPerWave);
    }
    bool IsBossWave()
    {
        return bossWaveInterval > 0 && currentWave % bossWaveInterval == 0;
    }
    void SpawnBoss()
    {
        if (playerIsDead) return;

        if (bossPrefab == null)
        {
            Debug.LogWarning("Boss prefab is missing.");
            return;
        }

        Instantiate(bossPrefab, transform.position, Quaternion.identity);

        activeEnemyCount++;
        enemiesSpawnedThisWave++;
        bossSpawnedThisWave = true;

        Debug.Log("Boss spawned for Wave " + currentWave);
    }
}
