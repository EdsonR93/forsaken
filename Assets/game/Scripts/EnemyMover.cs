using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;
    private float moveSpeed;
    private Transform playerTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (enemyStats == null)
        {
            Debug.LogError(gameObject.name + " is missing EnemyStats.");
            enabled = false;
            return;
        }

        moveSpeed = enemyStats.MovementSpeed;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            playerTarget = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player object not found in the scene.");
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTarget != null)
        {
            Vector2 nextPosition = Vector2.MoveTowards(
                transform.position,
                playerTarget.position,
                moveSpeed * Time.deltaTime
            );
            transform.position = nextPosition;
        }
        
    }
}
