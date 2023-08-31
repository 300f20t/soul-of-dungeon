using UnityEngine;

public class PlayerRotation : MonoBehaviour

{
    public KeyCode rotateLeft = KeyCode.A;
    public KeyCode rotateRight = KeyCode.D;

    void Update()
    {
        if (Input.GetKeyDown(rotateRight))
        {
            transform.Rotate(0f, 180f, 0f);
        }

        if (Input.GetKeyDown(rotateLeft))
        {
            transform.Rotate(0f, 180f, 0f);
        }
    }
}