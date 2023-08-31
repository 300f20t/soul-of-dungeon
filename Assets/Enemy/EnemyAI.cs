using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 5f;
    public float stoppingDistance = 1f;

    private GameObject player;
    private NavMeshAgent navMeshAgent;
    private bool playerDetected = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // ��������� ��������� NavMeshAgent, ���� ��� ��� ���
        if (!TryGetComponent<NavMeshAgent>(out navMeshAgent))
        {
            navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
            navMeshAgent.enabled = false; // ��������� ��� �� ���������
        }
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (!playerDetected && distanceToPlayer <= detectionRange)
            {
                playerDetected = true;
                navMeshAgent.enabled = true; // �������� NavMeshAgent ��� ����������� ������
                navMeshAgent.SetDestination(player.transform.position);
            }

            if (playerDetected)
            {
                if (distanceToPlayer > detectionRange)
                {
                    playerDetected = false;
                    navMeshAgent.enabled = false; // ��������� NavMeshAgent, ���� ����� ����� �� ���������
                }
                else
                {
                    if (distanceToPlayer <= stoppingDistance)
                    {
                        navMeshAgent.isStopped = true; // ������������� ������, ����� �� ������ � ������
                    }
                    else
                    {
                        navMeshAgent.isStopped = false;
                    }
                }
            }
        }
    }
}
