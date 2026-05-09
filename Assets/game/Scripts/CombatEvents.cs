
using System;
using UnityEngine;

public static class CombatEvents
{
    // Events declaration
    // Event when an attack is initiated. Parameters: attacker, target.
    public static event Action<Transform, Transform> OnAttack;
    // Event when an attack hits. Parameters: attacker, target, damage.
    public static event Action<Transform, Transform, float> OnHit;
    // Event when a character dies. Parameters: character.
    public static event Action<Transform> OnDeath;

    // Event Behavior / Triggers
    // Call this method to trigger the OnAttack event
    public static void TriggerAttack(Transform attacker, Transform target)
    {
        Debug.Log("Attack event triggered: " + attacker.name + " -> " + target.name);
        OnAttack?.Invoke(attacker, target);
        
    }

    // Call this method to trigger the OnHit event
    public static void TriggerHit(Transform attacker, Transform target, float damage)
    {
        Debug.Log("Hit event triggered: " + attacker.name + " hit " + target.name + " for " + damage);
        OnHit?.Invoke(attacker, target, damage);
    }

    // Call this method to trigger the OnDeath event
    public static void TriggerDeath(Transform character)
    {
        Debug.Log("Death event triggered: " + character.name);
        OnDeath?.Invoke(character);
    }

}
