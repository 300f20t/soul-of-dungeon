using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damageAmount = 10; // Количество урона, наносимого врагом игроку

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Вызываем функцию, которая обрабатывает урон игроку
            other.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        }
    }
}
