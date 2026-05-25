using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackInterval = 1.5f;

    private float attackDamage;
    private float attackTimer;
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

    void Start()
    {
        if (enemyStats == null)
        {
            Debug.LogError(gameObject.name + " is missing EnemyStats.");
            enabled = false;
            return;
        }

        attackDamage = enemyStats.AttackDamage;
        //Debug.Log(gameObject.name + " attack damage loaded: " + attackDamage);

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj == null)
        {
            Debug.LogError("Player object not found in the scene.");
            enabled = false;
            return;
        }
        playerTarget = playerObj.transform;
        PlayerHealth playerHealth = playerTarget.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerIsDead = playerHealth.IsDead;
            //Debug.Log(gameObject.name + " detected player death state on spawn: " + playerIsDead);
        }
        else
        {
            Debug.LogWarning("PlayerHealth component not found on Player.");
        }

        if (attackInterval <= 0)
        {
            Debug.LogError(gameObject.name + " attack interval must be greater than zero.");
            attackInterval = 1f;
        }

        if (attackRange <= 0)
        {
            Debug.LogError(gameObject.name + " attack range must be greater than zero.");
            attackRange = 2.6f;
        }

        attackTimer = attackInterval; // Start the timer so the enemy can attack immediately
    }

    void Update()
    {
        if (playerTarget == null) return;
        if (playerIsDead) return;

        attackTimer += Time.deltaTime;

        float distanceToPlayer = Vector2.Distance(transform.position, playerTarget.position);
        if (distanceToPlayer <= attackRange && attackTimer >= attackInterval)
        {
            Attack();
            attackTimer = 0f; // Reset the timer after attacking
        }

    }

    void Attack()
    {
        if (playerIsDead) return;

        CombatEvents.TriggerAttack(transform, playerTarget);
        CombatEvents.TriggerHit(transform, playerTarget, attackDamage);
        Debug.Log(gameObject.name + " attacked " + playerTarget.name + " for " + attackDamage + " damage.");
    }

    void HandleDeath(Transform character)
    {
        if (character.CompareTag("Player"))
        {
            playerIsDead = true;
        }
    }
}