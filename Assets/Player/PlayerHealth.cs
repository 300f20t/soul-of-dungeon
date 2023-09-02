using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // ������������ �������� ������
    private int currentHealth;  // ������� �������� ������
    public Text healthText;     // ��������� ���� ��� ����������� �������� ������

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
        Debug.Log("����� �����!");
        // �������������� ��������� ������ ������, ���� ����������
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "��������: " + currentHealth.ToString();
        }
    }
}
