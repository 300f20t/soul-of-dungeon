using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject solidWallPrefab;   // Префаб твёрдой стены
    public GameObject softWallPrefab;    // Префаб нетвёрдой стены
    public Vector3 initialSpawnPosition; // Позиция спавна первой комнаты
    public int roomWidth = 10;           // Ширина комнаты
    public int roomHeight = 6;           // Высота комнаты
    public int numberOfRooms = 5;        // Количество комнат
    public float wallSize = 1.0f;        // Размер блока стены
    public float roomSpacing = 5.0f;     // Расстояние между комнатами

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

            // Вычисляем следующую позицию для комнаты
            spawnPosition += setRandomDirection * roomSpacing;
        }
    }

    void GenerateRoom(Vector3 spawnPosition, int randomDirection)
    {

    }
}
