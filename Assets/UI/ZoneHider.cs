using UnityEngine;
using UnityEngine.UI;

public class ZoneHider : MonoBehaviour
{
    [SerializeField] private BoxCollider2D zoneCollider; // 2D ���������, ������������ ����
    [SerializeField] private GameObject[] objectsToHide; // ������ UI ��������, ������� ����� ������

    private bool isInZone = false; // ����, ������������, ��������� �� ����� � ����

    private void Start()
    {
        if (zoneCollider == null)
        {
            Debug.LogError("Zone Collider is not assigned!");
        }
    }

    private void Update()
    {
        // ���������, ��������� �� ����� � ����
        if (zoneCollider != null)
        {
            Vector3 position = transform.position;
            Vector3 zoneMin = zoneCollider.bounds.min;
            Vector3 zoneMax = zoneCollider.bounds.max;

            if (position.x >= zoneMin.x && position.x <= zoneMax.x &&
                position.y >= zoneMin.y && position.y <= zoneMax.y)
            {
                // ���� � ����
                if (!isInZone)
                {
                    isInZone = true;
                    ShowObjects(false); // �������� ������� ��� ����� � ����
                }
            }
            else
            {
                // ����� �� ����
                if (isInZone)
                {
                    isInZone = false;
                    ShowObjects(true); // ���������� ������� ��� ������ �� ����
                }
            }
        }
    }

    private void ShowObjects(bool show)
    {
        // ���������� ��� ������������ ������� � ����������� �� ��������� show
        foreach (var obj in objectsToHide)
        {
            obj.SetActive(show);
        }
    }
}
