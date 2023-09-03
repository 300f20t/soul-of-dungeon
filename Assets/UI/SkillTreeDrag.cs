using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillTreeDrag : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Vector3 offset;

    [SerializeField] private Vector3 maxPosition; // ������������ �������
    [SerializeField] private Vector3 minPosition; // ����������� �������

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
            // ������������ ������� � �������� ������������ � ����������� �������
            Vector3 newPosition = localCursor + offset;
            newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
            newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);
            newPosition.z = Mathf.Clamp(newPosition.z, minPosition.z, maxPosition.z);
            rectTransform.anchoredPosition3D = newPosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // ����� �� ������ ��������� �����-���� �������� �� ���������� ��������������
    }
}
