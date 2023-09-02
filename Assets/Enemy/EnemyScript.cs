using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private int scoreValue = 10; // значение очков за убийство врага
    private ScoreScript scoreScript; // ссылка на ScoreScript

    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
        scoreScript = FindObjectOfType<ScoreScript>(); // Найти объект с ScoreScript и получить ссылку
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        if (scoreScript != null)
        {
            scoreScript.AddScore(scoreValue); // Вызвать метод AddScore в ScoreScript
        }
        Destroy(gameObject);
    }
}
