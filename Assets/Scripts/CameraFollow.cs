using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform target;
    public Vector3 offset = new Vector3(0f, 10f, -10f);
   
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset; // Set the camera's position to follow the target with the specified offset

    }
}
