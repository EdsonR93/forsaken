using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    private bool isDead = false;
    public bool IsDead => isDead;

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
        if (maxHealth == 0)
        {
            Debug.LogError(gameObject.name + " has zero max health.");
            enabled = false;
            return;
        }
        currentHealth = maxHealth;
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
        transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        GetComponent<PlayerAutoAttack>().enabled = false;
        
        Debug.Log(gameObject.name + " has died.");
        CombatEvents.TriggerDeath(transform);
        // Implement respawn or game over logic here
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        if (damage < 0)
        {
            Debug.LogWarning("Damage must be greater than zero.");
            return;
        }
        currentHealth -= damage;
        Debug.Log(gameObject.name + " took " + damage + " damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
}