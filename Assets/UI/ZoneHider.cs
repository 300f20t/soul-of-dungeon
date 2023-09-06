using UnityEngine;

public class ZoneHider : MonoBehaviour
{
    [SerializeField] private Vector3 maxPosition; // Максимальная позиция
    [SerializeField] private Vector3 minPosition; // Минимальная позиция
    [SerializeField] private RectTransform objectToHide; // Используем RectTransform

    private void Update()
    {
        Vector3 objectPosition = objectToHide.anchoredPosition; // Получаем позицию RectTransform

        // Проверяем, находится ли объект внутри заданной зоны
        if (objectPosition.x >= minPosition.x && objectPosition.x <= maxPosition.x &&
            objectPosition.y >= minPosition.y && objectPosition.y <= maxPosition.y)
        {
            // Объект входит в зону, делаем его активным
            objectToHide.gameObject.SetActive(true);
        }
        else
        {
            // Объект покидает зону, делаем его неактивным
            objectToHide.gameObject.SetActive(false);
        }
    }
}