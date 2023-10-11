using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public int damageAmount = 10; // Количество урона, наносимого врагом игроку

    private void Start()
    {
            // Вызываем функцию, которая обрабатывает урон игроку
            player.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
    }
}
