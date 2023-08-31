using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    public WeaponHolder weaponHolder;
    public GameObject bulletPrefab;
    public int pelletsPerShot = 5;
    public float spreadAngle = 20f;
    public float bulletSpeed = 10f;
    public KeyCode shootKey = KeyCode.Mouse0;

    private bool isShooting = false;

    void Update()
    {
        if (!isShooting && Input.GetKeyDown(shootKey))
        {
            isShooting = true;
            Shoot();
        }
    }

    void Shoot()
    {
        BaseWeaponShooting[] weapons = FindObjectsOfType<BaseWeaponShooting>();

        foreach (BaseWeaponShooting weapon in weapons)
        {
            if (weaponHolder.canShoot)
            {
                for (int i = 0; i < pelletsPerShot; i++)
                {
                    float angle = Random.Range(-spreadAngle, spreadAngle);
                    Quaternion rotation = Quaternion.Euler(0f, 0f, angle) * weapon.firePoint.rotation;

                    GameObject bullet = Instantiate(bulletPrefab, weapon.firePoint.position, rotation);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                    rb.velocity = rotation * Vector2.right * bulletSpeed;
                }
            }
        }

        StartCoroutine(ResetShooting());
    }

    System.Collections.IEnumerator ResetShooting()
    {
        yield return new WaitForSeconds(0.2f);
        isShooting = false;
    }
}
