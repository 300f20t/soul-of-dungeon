using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillTreeDrag : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Vector3 offset;

    [SerializeField] private Vector3 maxPosition; // ћаксимальна€ позици€
    [SerializeField] private Vector3 minPosition; // ћинимальна€ позици€

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // –ассчитываем смещение между позицией курсора и текущей позицией дочерних объектов
        Vector3 localCursor;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localCursor))
        {
            offset = rectTransform.anchoredPosition3D - localCursor;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ѕолучаем новую позицию курсора
        Vector3 localCursor;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localCursor))
        {
            // ќграничиваем позицию в пределах максимальной и минимальной позиций
            Vector3 newPosition = localCursor + offset;
            newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
            newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);
            newPosition.z = Mathf.Clamp(newPosition.z, minPosition.z, maxPosition.z);
            rectTransform.anchoredPosition3D = newPosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // «десь вы можете выполнить какие-либо действи€ по завершении перетаскивани€
    }
}
