using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour
{
    [SerializeField] private float attackInterval;
    [SerializeField] private float attackRange;
    private float attackTimer;

    void Start()
    {
        if (attackInterval <= 0)
        {
            Debug.LogError("Attack interval must be greater than zero.");
            attackInterval = 1; // Default to 1 second if invalid
            return;
        }
        if (attackRange <= 0)
        {
            Debug.LogError("Attack range must be greater than zero.");
            attackRange = 1; // Default to 1 unit if invalid
            return;
        }
        attackTimer = attackInterval;
    }

    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            PerformAttack();
            attackTimer = attackInterval;
        }
        
    }

    void PerformAttack()
    {
        Transform target = FindTargetInRange();
        if (target != null)
        {
            // Attack target logic here (e.g., reduce health, play animation)
            CombatEvents.TriggerAttack(transform, target);

            EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
            if (enemyHealth != null)            {
                enemyHealth.TakeDamage(10f); // Damage value
            }
        }else
        {
            Debug.Log("No target in range for auto attack.");
        }
    }

    Transform FindTargetInRange()
    {
        Vector2 playerPosition = transform.position;
        float closestEnemyDistance = float.MaxValue;
        Transform closestEnemy = null;

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(playerPosition, attackRange);
        foreach (var hitCollider in hitColliders)
        {
            if (!hitCollider.CompareTag("Enemy")) continue;

            float distanceToEnemy = Vector2.Distance(playerPosition, hitCollider.transform.position);

            if (distanceToEnemy < closestEnemyDistance)
            {
                closestEnemyDistance = distanceToEnemy;
                closestEnemy = hitCollider.transform;
            }
        }
        return closestEnemy;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}