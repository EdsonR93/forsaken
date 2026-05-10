using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Forsaken/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private bool isBoss = false;

}