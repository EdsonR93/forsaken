using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackInterval = 1.5f;
    
    private float attackDamage;
    private float attackTimer;
    private Transform playerTarget;

    void Start()
    {
        if (enemyStats == null)
        {
            Debug.LogError(gameObject.name + " is missing EnemyStats.");
            enabled = false;
            return;
        }

        attackDamage = enemyStats.AttackDamage;
        Debug.Log(gameObject.name + " attack damage loaded: " + attackDamage);

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

        attackTimer = attackInterval; // Start the timer so the enemy can attack immediately
    }

    void Update()
    {
        if (playerTarget == null) return;

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
        CombatEvents.TriggerAttack(transform, playerTarget);
        CombatEvents.TriggerHit(transform, playerTarget, attackDamage);
        Debug.Log(gameObject.name + " attacked " + playerTarget.name + " for " + attackDamage + " damage.");
    }
}