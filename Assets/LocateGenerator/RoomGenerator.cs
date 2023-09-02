using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField] private GameObject solidWallPrefab;   // ������ ������ �����
    [SerializeField] private GameObject softWallPrefab;    // ������ �������� �����
    [SerializeField] private Vector3 initialSpawnPosition; // ������� ������ ������ �������
    [SerializeField] private int roomWidth = 10;           // ������ �������
    [SerializeField] private int roomHeight = 6;           // ������ �������
    [SerializeField] private int numberOfRooms = 5;        // ���������� ������
    [SerializeField] private float wallSize = 1.0f;        // ������ ����� �����
    [SerializeField] private float roomSpacing = 5.0f;     // ���������� ����� ���������

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

            int randomDirection = 0; // Random.Range(0, 3);
            for (int x = 0; x < roomWidth; x++)
            {
                for (int y = 0; y < roomHeight; y++)
                {
                    Vector3 position = spawnPosition + new Vector3(x * wallSize, y * wallSize, 0);
                    Vector3 passagePosition = spawnPosition + new Vector3(x * wallSize, y * wallSize, 0);

                    int passagePositionY = roomHeight / 2;
                    int passagePositionX = roomWidth / 2;
                    bool n; // ���� �� � ����, ��� ��� �����, �� � �� ���� ��� ��� �����...
                    bool e; // ���� �� � ����, ��� ��� �����, �� � �� ���� ��� ��� �����...

                    switch (randomDirection) // ��� ����� ������� ���...
                    {
                        case 0:
                            if (i == 0)
                            {
                                n = x == 0;
                            }
                            else
                            {
                                n = x != 0;
                            }

                            e = y == passagePositionY + 1 && n || y == passagePositionY - 1 && n || y == passagePositionY && n;

                            if (e)
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
                            if (i == 0)
                            {
                                n = x != 0;
                            }
                            else
                            {
                                n = x == 0;
                            }

                            e = y == passagePositionY + 1 && n || y == passagePositionY - 1 && n || y == passagePositionY && n;

                            if (e)
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
                            if (i == 0)
                            {
                                n = y != 0;
                            }
                            else
                            {
                                n = y == 0;
                            }

                            e = x == passagePositionX + 1 && n || x == passagePositionX - 1 && n || x == passagePositionX && n;

                            if (e)
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
                            if (i == 0)
                            {
                                n = y == 0;
                            }
                            else
                            {
                                n = y != 0;
                            }

                            e = x == passagePositionX + 1 && n || x == passagePositionX - 1 && n || x == passagePositionX && n;

                            if (e)
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
}
