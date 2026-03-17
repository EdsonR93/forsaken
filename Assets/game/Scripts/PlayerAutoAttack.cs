using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour
{
    [SerializeField] private float attackInterval;
    private float attackTimer;

    void Start()
    {
        if (attackInterval <= 0)
        {
            Debug.LogError("Attack interval must be greater than zero.");
            attackInterval = 1; // Default to 1 second if invalid
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
        Debug.Log("Player performed auto attack");
    }
}