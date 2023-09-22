using UnityEngine;

public class RoomCloner : MonoBehaviour
{
    [SerializeField] private GameObject roomPrefab;
    [SerializeField] private Vector3 spawnOffset = new Vector3(10f, 0f, 0f);

    private GameObject previousRoom;

    public void Start()
    {
        if (roomPrefab == null)
        {
            Debug.LogWarning("Room prefab is not assigned!");
            return;
        }

        Debug.Log("Cloning room...");

        // Check the position from which the room is being cloned
        Debug.Log("Clone from position: " + transform.position);

        GameObject clonedRoom = Instantiate(roomPrefab, transform.position + spawnOffset, Quaternion.identity);

        previousRoom = clonedRoom;

        Debug.Log("Room cloned!");
    }
}
