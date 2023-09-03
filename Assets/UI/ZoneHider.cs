using UnityEngine;
using UnityEngine.UI;

public class ZoneHider : MonoBehaviour
{
    [SerializeField] private BoxCollider2D zoneCollider; // 2D коллайдер, обозначающий зону
    [SerializeField] private GameObject[] objectsToHide; // Массив UI объектов, которые нужно скрыть

    private bool isInZone = false; // Флаг, определяющий, находится ли игрок в зоне

    private void Start()
    {
        if (zoneCollider == null)
        {
            Debug.LogError("Zone Collider is not assigned!");
        }
    }

    private void Update()
    {
        // Проверяем, находится ли игрок в зоне
        if (zoneCollider != null)
        {
            Vector3 position = transform.position;
            Vector3 zoneMin = zoneCollider.bounds.min;
            Vector3 zoneMax = zoneCollider.bounds.max;

            if (position.x >= zoneMin.x && position.x <= zoneMax.x &&
                position.y >= zoneMin.y && position.y <= zoneMax.y)
            {
                // Вход в зону
                if (!isInZone)
                {
                    isInZone = true;
                    ShowObjects(false); // Скрываем объекты при входе в зону
                }
            }
            else
            {
                // Выход из зоны
                if (isInZone)
                {
                    isInZone = false;
                    ShowObjects(true); // Показываем объекты при выходе из зоны
                }
            }
        }
    }

    private void ShowObjects(bool show)
    {
        // Активируем или деактивируем объекты в зависимости от параметра show
        foreach (var obj in objectsToHide)
        {
            obj.SetActive(show);
        }
    }
}
