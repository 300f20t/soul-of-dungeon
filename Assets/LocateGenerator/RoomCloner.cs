using UnityEngine;

public class RoomCloner : MonoBehaviour
{
    [SerializeField] private GameObject roomPrefab;
    [SerializeField] private float maxOffsetDistance = 10f;

    public void CloneRoom()
    {
        if (roomPrefab == null)
        {
            Debug.LogWarning("Room prefab is not assigned!");
            return;
        }

        // Calculate a random direction vector
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        // Calculate the random offset distance within the specified range
        float randomOffsetDistance = Random.Range(0f, maxOffsetDistance);

        // Calculate the final position for the cloned room
        Vector3 newPosition = transform.position + new Vector3(randomDirection.x, 0f, randomDirection.y) * randomOffsetDistance;

        // Instantiate the cloned room at the new position
        GameObject clonedRoom = Instantiate(roomPrefab, newPosition, Quaternion.identity);

        Debug.Log("Room cloned at position: " + newPosition);
    }
}
