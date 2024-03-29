using UnityEngine;

public class Coin : MonoBehaviour
{
    private PlayerCoins playerCoins;
    [SerializeField] private float attractionForce = 5f; // ���� ����������
    [SerializeField] private float minDistanceToPlayer = 1f; // ����������� ���������� �� ������, ��� ������� ������ ����� �������
    [SerializeField] private float maxDistanceToPlayer = 10f; // ������������ ���������� �� ������, �� ������� ��������� ����������

    private Transform player;

    private void Start()
    {
        playerCoins = FindObjectOfType<PlayerCoins>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // ����� ������ �� ���� "Player"
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            float distanceToPlayer = directionToPlayer.magnitude;

            if (distanceToPlayer < minDistanceToPlayer)
            {
                playerCoins.AddCoins();
                // ������ ������ � ������, ������� �
                Destroy(gameObject);
            }
            else if (distanceToPlayer < maxDistanceToPlayer)
            {
                // ���������� ������ � ������
                Vector3 attractionDirection = directionToPlayer.normalized;
                GetComponent<Rigidbody2D>().AddForce(attractionDirection * attractionForce);
            }
        }
    }
}
