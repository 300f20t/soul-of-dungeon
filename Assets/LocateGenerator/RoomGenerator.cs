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

    protected void GenerateRooms()
    {
        Vector3 spawnPosition = initialSpawnPosition;

        for (int i = 0; i < numberOfRooms; i++)
        {
            Vector3 setRandomDirection = Vector3.zero;

            int randomDirection = Random.Range(0, 4);
            for (int x = 0; x < roomWidth; x++)
            {
                for (int y = 0; y < roomHeight; y++)
                {
                    Vector3 position = spawnPosition + new Vector3(x * wallSize, y * wallSize, 0);

                    int passagePosY = roomHeight / 2;
                    int passagePosX = roomWidth / 2;

                    switch (randomDirection)
                    {
                        case 0:
                            if (y == passagePosY + 1 && x == 0 || y == passagePosY - 1 && x == 0 || y == passagePosY && x == 0)
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
                            setRandomDirection = Vector3.left;
                            break;
                        case 1:
                            if (y == passagePosY + 1 && x != 0 || y == passagePosY - 1 && x != 0 || y == passagePosY && x != 0)
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
                            setRandomDirection = Vector3.right;
                            break;
                        case 2:
                            if (x == passagePosX + 1 && y != 0 || x == passagePosX - 1 && y != 0 || x == passagePosX && y != 0)
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
                            setRandomDirection = Vector3.up;
                            break;
                        case 3:
                            if (x == passagePosX + 1 && y == 0 || x == passagePosX - 1 && y == 0 || x == passagePosX && y == 0)
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
                            setRandomDirection = Vector3.down;
                            break;
                    }
                }
            }

            // ��������� ��������� ������� ��� �������
            spawnPosition += setRandomDirection * roomSpacing;
        }
    }

    void GenerateRoom(Vector3 spawnPosition, int randomDirection)
    {

    }
}
