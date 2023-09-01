using UnityEngine;

public class ShotgunShooting : MonoBehaviour
{
    public PlayerController playerController;
    public WeaponHolder weaponHolder;
    public GameObject bulletPrefab;
    public GameObject weaponPrefab;
    public Transform firePoint;
    public int pelletCount = 5; // ���������� �������� � ����� ��������
    public float spreadAngle = 20f; // ���� �������� ��������
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
                    // ������������ ���� �������� ��� ������� �������
                    float angle = Random.Range(-spreadAngle, spreadAngle);
                    Quaternion rotation = Quaternion.Euler(0, 0, angle);

                    // ������� ������ � ����������� ��� �������� � �����������
                    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
                    bullet.SetActive(true);

                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                    // ��������� ����������� � ������ ���� ��������
                    Vector3 shootDirection = rotation * firePoint.right;

                    rb.velocity = shootDirection * shootSpeed;
                }
            }
        }
    }
}
