using UnityEngine;

public class CombatEventLogger : MonoBehaviour
{
    void OnEnable()
    {
        Debug.Log("CombatEventLogger subscribed");
        CombatEvents.OnAttack += HandleAttack;
        CombatEvents.OnHit += HandleHit;
        CombatEvents.OnDeath += HandleDeath;
    }

    void OnDisable()
    {
        Debug.Log("CombatEventLogger subscribed");
        CombatEvents.OnAttack -= HandleAttack;
        CombatEvents.OnHit -= HandleHit;
        CombatEvents.OnDeath -= HandleDeath;
    }

    void HandleAttack(Transform attacker, Transform target)
    {
        Debug.Log("CombatEventLogger: " + attacker.name + " attacked " + target.name);
    }

    void HandleHit(Transform attacker, Transform target, float damage)
    {
        Debug.Log("CombatEventLogger: " + attacker.name + " hit " + target.name + " for " + damage + " damage");
    }

    void HandleDeath(Transform character)
    {
        Debug.Log("CombatEventLogger: " + character.name + " has died");
    }
}