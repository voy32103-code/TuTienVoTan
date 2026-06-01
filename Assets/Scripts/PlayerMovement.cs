using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5f; // Speed of the player movement
    private CharacterController characterController; // Reference to the CharacterController component

    void Start()
    {
        characterController = GetComponent<CharacterController>(); // Get the CharacterController component attached to the player

    }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)
        float vertical = Input.GetAxis("Vertical"); // Get vertical input (W/S or Up/Down arrow keys)
        Vector3 direction =  new Vector3(horizontal, 0f, vertical).normalized; // Create a direction vector based on input
        characterController.Move(direction * speed * Time.deltaTime); // Move the player using the CharacterController

    }
    public void IncreaseSpeed(float amount)
    {
        speed += amount;
        Debug.Log("Tốc độ hiện tại: " + speed);
    }
}
