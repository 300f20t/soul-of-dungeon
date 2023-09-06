using UnityEngine;

public class ZoneHider : MonoBehaviour
{
    [SerializeField] private Vector3 maxPosition; // ������������ �������
    [SerializeField] private Vector3 minPosition; // ����������� �������
    [SerializeField] private RectTransform objectToHide; // ���������� RectTransform

    private void Update()
    {
        Vector3 objectPosition = objectToHide.anchoredPosition; // �������� ������� RectTransform

        // ���������, ��������� �� ������ ������ �������� ����
        if (objectPosition.x >= minPosition.x && objectPosition.x <= maxPosition.x &&
            objectPosition.y >= minPosition.y && objectPosition.y <= maxPosition.y)
        {
            // ������ ������ � ����, ������ ��� ��������
            objectToHide.gameObject.SetActive(true);
        }
        else
        {
            // ������ �������� ����, ������ ��� ����������
            objectToHide.gameObject.SetActive(false);
        }
    }
}