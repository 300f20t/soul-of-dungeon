using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillTreeDrag : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Vector3 offset;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
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
            // Устанавливаем новую позицию дочерних объектов с учетом смещения
            rectTransform.anchoredPosition3D = localCursor + offset;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Здесь вы можете выполнить какие-либо действия по завершении перетаскивания
    }
}
