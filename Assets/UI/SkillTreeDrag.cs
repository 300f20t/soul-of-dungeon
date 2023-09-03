using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillTreeDrag : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Vector3 offset;

    [SerializeField] private GameObject objectToDrag; // Объект для перетаскивания
    [SerializeField] private Vector3 maxPosition; // Максимальная позиция
    [SerializeField] private Vector3 minPosition; // Минимальная позиция

    private void Awake()
    {
        rectTransform = objectToDrag.GetComponent<RectTransform>(); // Используем RectTransform объекта для перетаскивания
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Рассчитываем смещение между позицией курсора и текущей позицией дочерних объектов
        Vector3 localCursor;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localCursor))
        {
            offset = rectTransform.anchoredPosition3D - localCursor;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Получаем новую позицию курсора
        Vector3 localCursor;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localCursor))
        {
            // Ограничиваем позицию в пределах максимальной и минимальной позиций
            Vector3 newPosition = localCursor + offset;
            newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
            newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);
            newPosition.z = Mathf.Clamp(newPosition.z, minPosition.z, maxPosition.z);
            rectTransform.anchoredPosition3D = newPosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Здесь вы можете выполнить какие-либо действия по завершении перетаскивания
    }
}
