using UnityEngine;

public class EnemyIdentity : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;
    private bool isBoss;

    void Start()
    {
        if (enemyStats == null)
        {
            Debug.LogError(gameObject.name + " is missing EnemyStats.");
            enabled = false;
            return;
        }

        isBoss = enemyStats.IsBoss;
        Debug.Log(gameObject.name + " isBoss: " + isBoss);
    }
}