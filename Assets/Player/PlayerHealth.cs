using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int HP = 100;

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
    }
    public void Update()
    {
        Debug.Log(HP);
    }
}
