using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ZoneHider : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject[] objectsToShow; // ������ �������� ��� �����������

    // ����������, ����� ���� ������ � ����
    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (GameObject obj in objectsToShow)
        {
            obj.SetActive(true); // ���������� �������
        }
    }

    // ����������, ����� ���� ������� �� ����
    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (GameObject obj in objectsToShow)
        {
            obj.SetActive(false); // �������� �������
        }
    }
}
