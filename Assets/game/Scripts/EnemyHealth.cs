using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;
    private float currentHealth;
    private bool isDead = false;

    void OnEnable()
    {
        CombatEvents.OnHit += HandleHit;
    }

    void OnDisable()
    {
        CombatEvents.OnHit -= HandleHit;
    }

    void Start()
    {
        if (enemyStats == null)
        {
            Debug.LogError(gameObject.name + " is missing EnemyStats.");
            enabled = false;
            return;
        }
        currentHealth = enemyStats.MaxHealth;
    }

    void Update()
    {

    }

    void HandleHit(Transform attacker, Transform target, float damage)
    {
        if (target != transform) return;

        TakeDamage(damage);
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        EnemyMover mover = GetComponent<EnemyMover>();
        if (mover != null)
        {
            mover.enabled = false;
        }

        EnemyAttack attack = GetComponent<EnemyAttack>();
        if (attack != null)
        {
            attack.enabled = false;
        }

        Debug.Log(gameObject.name + " has died.");
        CombatEvents.TriggerDeath(transform);
        Destroy(gameObject, 1f);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            Debug.LogWarning("Damage must be greater than zero.");
            return;
        }
        currentHealth -= damage;
        //Debug.Log(gameObject.name + " took " + damage + " damage. Current health: " + currentHealth);
        if (currentHealth <= 0)
        {

            Die();
        }
    }
}