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
        // ������������ �������� ����� �������� ������� � ������� �������� �������� ��������
        Vector3 localCursor;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localCursor))
        {
            offset = rectTransform.anchoredPosition3D - localCursor;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // �������� ����� ������� �������
        Vector3 localCursor;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localCursor))
        {
            // ������������� ����� ������� �������� �������� � ������ ��������
            rectTransform.anchoredPosition3D = localCursor + offset;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // ����� �� ������ ��������� �����-���� �������� �� ���������� ��������������
    }
}
