using UnityEngine;

public class ScaleObjectWithMouseWheel : MonoBehaviour
{
    public GameObject objectToScale; // ������, ������� �������� �� ����� ��������
    public float minScale = 0.5f;    // ����������� �������
    public float maxScale = 2.0f;    // ������������ �������
    public float scrollSpeed = 0.1f; // �������� ��������� ��������

    void Update()
    {
        if (objectToScale == null)
        {
            Debug.LogError("Object to scale is not assigned.");
            return;
        }

        // �������� �������� ��������� �������� ����
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // �������� ������� ������� �� ������ �������� ���������
        objectToScale.transform.localScale += new Vector3(scroll, scroll, scroll) * scrollSpeed;

        // ������������ ������� � �������� minScale � maxScale
        objectToScale.transform.localScale = new Vector3(
            Mathf.Clamp(objectToScale.transform.localScale.x, minScale, maxScale),
            Mathf.Clamp(objectToScale.transform.localScale.y, minScale, maxScale),
            Mathf.Clamp(objectToScale.transform.localScale.z, minScale, maxScale)
        );
    }
}
