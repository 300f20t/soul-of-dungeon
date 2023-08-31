using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject solidWallPrefab;   // ������ ������ �����
    public GameObject softWallPrefab;    // ������ �������� �����
    public Vector3 initialSpawnPosition; // ������� ������ ������ �������
    public int roomWidth = 10;           // ������ �������
    public int roomHeight = 6;           // ������ �������
    public int numberOfRooms = 5;        // ���������� ������
    public float wallSize = 1.0f;        // ������ ����� �����
    public float roomSpacing = 5.0f;     // ���������� ����� ���������

    void Start()
    {
        GenerateRooms();
    }

    void GenerateRooms()
    {
        Vector3 spawnPosition = initialSpawnPosition;

        for (int i = 0; i < numberOfRooms; i++)
        {
            GenerateRoom(spawnPosition);

            // �������� ��������� ����������� (�����, ������, �����, ����)
            int randomDirection = Random.Range(0, 4);
            Vector3 setRandomDirection = Vector3.zero;

            switch (randomDirection)
            {
                case 0:
                    setRandomDirection = Vector3.left;
                    break;
                case 1:
                    setRandomDirection = Vector3.right;
                    break;
                case 2:
                    setRandomDirection = Vector3.up;
                    break;
                case 3:
                    setRandomDirection = Vector3.down;
                    break;
            }

            // ��������� ��������� ������� ��� �������
            spawnPosition += setRandomDirection * roomSpacing;
        }
    }

    void GenerateRoom(Vector3 spawnPosition)
    {
        for (int x = 0; x < roomWidth; x++)
        {
            for (int y = 0; y < roomHeight; y++)
            {
                Vector3 position = spawnPosition + new Vector3(x * wallSize, y * wallSize, 0);

                bool passagePosition = y == roomHeight / 2;

                if (y == roomHeight / 2 + 1 && x != 0)
                {
                    GameObject wall = Instantiate(softWallPrefab, position, Quaternion.identity);
                    wall.SetActive(true);
                }
                else if (x == 0 || x == roomWidth - 1 || y == 0 || y == roomHeight - 1)
                {
                    GameObject wall = Instantiate(solidWallPrefab, position, Quaternion.identity);
                    wall.SetActive(true);
                }
                else
                {
                    GameObject wall = Instantiate(softWallPrefab, position, Quaternion.identity);
                    wall.SetActive(true);
                }
            }
        }
    }
}
