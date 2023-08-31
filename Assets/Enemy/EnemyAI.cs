using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float detectionRange = 5f;
    public float stoppingDistance = 1f;

    private GameObject player;
    private bool playerDetected = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null && !playerDetected)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= detectionRange)
            {
                playerDetected = true;
            }
        }

        if (playerDetected)
        {
            if (player != null)
            {
                Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
                transform.position += directionToPlayer * movementSpeed * Time.deltaTime;
            }
        }
    }

}