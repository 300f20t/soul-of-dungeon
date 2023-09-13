using UnityEngine;

public class RoomCloner : MonoBehaviour
{
    [SerializeField] private GameObject roomPrefab; // Reference to the room prefab you want to clone

    public void CloneRoom()
    {
        // Check if the prefab is assigned
        if (roomPrefab == null)
        {
            Debug.LogWarning("Room prefab is not assigned!");
            return;
        }

        // Clone the room prefab
        GameObject clonedRoom = Instantiate(roomPrefab, transform.position, Quaternion.identity);

        // Optionally, you can customize the cloned room further, such as adjusting its position or properties.
    }
}
