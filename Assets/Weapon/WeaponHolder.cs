using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public float pickupRadius = 2f;
    public LayerMask weaponLayer;
    public Transform spawnPoint;
    public KeyCode pickupKey = KeyCode.E;
    public bool canShoot = false;
    public GameObject currentWeapon;

    private bool isPickingUp = false; // Добавляем флаг для предотвращения повторных выстрелов

    public delegate void WeaponPickupAction();
    public event WeaponPickupAction OnWeaponPickup;

    public delegate void WeaponDropAction();
    public event WeaponDropAction OnWeaponDrop;

    private void Update()
    {
        if (Input.GetKeyDown(pickupKey) && !isPickingUp)
        {
            if (currentWeapon == null)
            {
                isPickingUp = true; // Устанавливаем флаг перед поднятием оружия

                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pickupRadius, weaponLayer);
                GameObject closestWeapon = null;
                float closestDistance = float.MaxValue;

                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("Weapon"))
                    {
                        float distance = Vector2.Distance(transform.position, collider.transform.position);
                        if (distance < closestDistance)
                        {
                            canShoot = true;
                            closestWeapon = collider.gameObject;
                            closestDistance = distance;
                        }
                    }
                }

                if (closestWeapon != null)
                {
                    currentWeapon = closestWeapon;
                    currentWeapon.transform.SetParent(transform);
                    currentWeapon.transform.localPosition = Vector3.zero;
                    currentWeapon.transform.localRotation = Quaternion.identity;
                    currentWeapon.SetActive(true);

                    currentWeapon.transform.position = spawnPoint.position;
                    currentWeapon.transform.rotation = spawnPoint.rotation;

                    OnWeaponPickup?.Invoke();
                }

                isPickingUp = false; // Сбрасываем флаг после поднятия оружия
            }
            else
            {
                RemoveWeaponFromHolder();
            }
        }
    }

    private void RemoveWeaponFromHolder()
    {
        currentWeapon.transform.SetParent(null);
        currentWeapon = null;
        canShoot = false;

        OnWeaponDrop?.Invoke();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}
