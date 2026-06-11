using UnityEngine;
public class EnemyRuntimeStats : MonoBehaviour
{
    public float MaxHealth { get; private set; }
    public float AttackDamage { get; private set; }
    public float MovementSpeed { get; private set; }
    public bool IsBoss { get; private set; }

    public void Initialize(
    float maxHealth,
    float attackDamage,
    float movementSpeed,
    bool isBoss)
    {
        MaxHealth = maxHealth;
        AttackDamage = attackDamage;
        MovementSpeed = movementSpeed;
        IsBoss = isBoss;
    }
}