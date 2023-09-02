using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Максимальное здоровье игрока
    private int currentHealth;  // Текущее здоровье игрока
    public Text healthText;     // Текстовое поле для отображения здоровья игрока

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Игрок погиб!");
        // Дополнительная обработка смерти игрока, если необходимо
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Здоровье: " + currentHealth.ToString();
        }
    }
}
