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
            // Implement attack logic here (e.g., reduce enemy health)
                Debug.Log("Attacked " + target.name);
        }else
        {
            Debug.Log("No target in range for auto attack.");
        }
    }

    Transform FindTargetInRange()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                return hitCollider.transform;
            }
        }
        return null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}