using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damageAmount = 10; // ���������� �����, ���������� ������ ������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �������� �������, ������� ������������ ���� ������
            other.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        }
    }
}
