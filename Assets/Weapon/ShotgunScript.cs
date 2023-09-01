using UnityEngine;

public class ShotgunShooting : MonoBehaviour
{
    public PlayerController playerController;
    public WeaponHolder weaponHolder;
    public GameObject bulletPrefab;
    public GameObject weaponPrefab;
    public Transform firePoint;
    public int pelletCount = 5; //  оличество снар€дов в одном выстреле
    public float spreadAngle = 20f; // ”гол разброса снар€дов
    public float shootSpeed = 10f;
    public float shotDelay = 0.2f;

    private float lastShotTime;

    void Start()
    {
        lastShotTime = -shotDelay;
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
                for (int i = 0; i < pelletCount; i++)
                {
                    // –ассчитываем угол разброса дл€ каждого снар€да
                    float angle = Random.Range(-spreadAngle, spreadAngle);
                    Quaternion rotation = Quaternion.Euler(0, 0, angle);

                    // —оздаем снар€д и настраиваем его скорость и направление
                    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
                    bullet.SetActive(true);

                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                    // ¬ычисл€ем направление с учетом угла разброса
                    Vector3 shootDirection = rotation * firePoint.right;

                    rb.velocity = shootDirection * shootSpeed;
                }
            }
        }
    }
}
