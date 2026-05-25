using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private float stoppingDistance = 0.75f;
    private float moveSpeed;
    private Transform playerTarget;
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
        if (enemyStats == null)
        {
            Debug.LogError(gameObject.name + " is missing EnemyStats.");
            enabled = false;
            return;
        }

        moveSpeed = enemyStats.MovementSpeed;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            playerTarget = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player object not found in the scene.");
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTarget == null) return;
        if (playerIsDead) return;

        float distanceToPlayer = Vector2.Distance(transform.position, playerTarget.position);
        if (distanceToPlayer <= stoppingDistance) return;

        Vector2 nextPosition = Vector2.MoveTowards(
            transform.position,
            playerTarget.position,
            moveSpeed * Time.deltaTime
        );
        transform.position = nextPosition;


    }

    void HandleDeath(Transform character)
    {
        if (character.CompareTag("Player"))
        {
            playerIsDead = true;
        }
    }
}
