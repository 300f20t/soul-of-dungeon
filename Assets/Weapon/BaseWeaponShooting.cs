using UnityEngine;

public class BaseWeaponShooting : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private WeaponHolder weaponHolder;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject weaponPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float shootSpeed = 10f;
    [SerializeField] private float shotDelay = 0.2f; // Задержка между выстрелами

    private float lastShotTime;

    void Start()
    {
        lastShotTime = -shotDelay; // Чтобы можно было стрелять сразу после запуска игры
    }

    void Update()
    {
        if (weaponHolder.canShoot && Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time - lastShotTime >= shotDelay)
            {
                Shoot();
                lastShotTime = Time.time;
            }
        }
    }

    void Shoot()
    {
        if (firePoint != null)
        {
            GameObject currentWeapon = weaponHolder.currentWeapon;

            if (currentWeapon == weaponPrefab)
            {
                Vector3 shootDirection = firePoint.right;

                if (firePoint.localScale.x < 0)
                {
                    shootDirection = -shootDirection;
                }

                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                bullet.SetActive(true);

                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = shootDirection * shootSpeed;
            }
        }
    }
}
