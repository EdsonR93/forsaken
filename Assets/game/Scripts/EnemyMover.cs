using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;
    private Transform playerTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            playerTarget = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player object not found in the scene.");
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
