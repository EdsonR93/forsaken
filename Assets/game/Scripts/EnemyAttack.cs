using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;
    private Transform playerTarget;
    private float attackDamage;

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
    }

    void Update()
    {
        
    }

    void Attack()
    {
        //CombatEvents.TriggerAttack(transform, playerTarget);
    }
}