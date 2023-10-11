using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public int damageAmount = 10; // ���������� �����, ���������� ������ ������

    private void Start()
    {
            // �������� �������, ������� ������������ ���� ������
            player.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
    }
}
