using UnityEngine;

public class ScaleObjectWithMouseWheel : MonoBehaviour
{
    public GameObject objectToScale; // Объект, масштаб которого мы хотим изменять
    public float minScale = 0.5f;    // Минимальный масштаб
    public float maxScale = 2.0f;    // Максимальный масштаб
    public float scrollSpeed = 0.1f; // Скорость изменения масштаба

    void Update()
    {
        if (objectToScale == null)
        {
            Debug.LogError("Object to scale is not assigned.");
            return;
        }

        // Получаем значение прокрутки колесика мыши
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Изменяем масштаб объекта на основе значения прокрутки
        objectToScale.transform.localScale += new Vector3(scroll, scroll, scroll) * scrollSpeed;

        // Ограничиваем масштаб в пределах minScale и maxScale
        objectToScale.transform.localScale = new Vector3(
            Mathf.Clamp(objectToScale.transform.localScale.x, minScale, maxScale),
            Mathf.Clamp(objectToScale.transform.localScale.y, minScale, maxScale),
            Mathf.Clamp(objectToScale.transform.localScale.z, minScale, maxScale)
        );
    }
}
