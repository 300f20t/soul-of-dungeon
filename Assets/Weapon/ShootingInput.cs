using UnityEngine;

public class ShootingInput : MonoBehaviour
{
    public delegate void ShootAction();
    public static event ShootAction OnShoot;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnShoot?.Invoke();
        }
    }
}
