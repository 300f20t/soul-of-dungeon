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

            int randomDirection = 0; // Random.Range(0, 3);
            for (int x = -1; x < roomWidth + 2; x++)
            {
                for (int y = -1; y < roomHeight +2; y++)
                {
                    Vector3 position = spawnPosition + new Vector3(x * wallSize, y * wallSize, 0);
                    Vector3 passagePosition = spawnPosition + new Vector3(x * wallSize, y * wallSize, 0);

                    int passagePositionY = roomHeight / 2;
                    int passagePositionX = roomWidth / 2;
                    bool n; // Если бы я знал, что это такое, но я не знаю что это такое...
                    bool e; // Если бы я знал, что это такое, но я не знаю что это такое...

                    switch (randomDirection) // Тут самый обычный код...
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

            

            // Вычисляем следующую позицию для комнаты
            spawnPosition += setRandomDirection * roomSpacing;
        }
    }
}
