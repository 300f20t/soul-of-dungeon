using UnityEngine;

public class Coin : MonoBehaviour
{
    private PlayerCoins playerCoins;
    public float attractionForce = 5f; // Сила притяжения
    public float minDistanceToPlayer = 1f; // Минимальное расстояние до игрока, при котором монета будет удалена
    public float maxDistanceToPlayer = 10f; // Максимальное расстояние до игрока, на котором действует притяжение

    private Transform player;

    private void Start()
    {
        playerCoins = FindObjectOfType<PlayerCoins>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Найти игрока по тегу "Player"
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
                // Монета близко к игроку, удаляем её
                Destroy(gameObject);
            }
            else if (distanceToPlayer < maxDistanceToPlayer)
            {
                // Притяжение монеты к игроку
                Vector3 attractionDirection = directionToPlayer.normalized;
                GetComponent<Rigidbody2D>().AddForce(attractionDirection * attractionForce);
            }
        }
    }
}
