using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflinePlayerController : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 100f;
    public float mouseSensitivity = 100f;

    Vector3 velocity;

    public float gravity = -9.8f;

    public Transform playerBody;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool isGrounded;

    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();

    }

    void CreateRay()
    {
        Ray hit;
    }

    private void MovePlayer()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void RotatePlayer()
    {

        // Rotation of the player
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        //playerBody.Rotate(Vector3.up * mouseX);
    }
}
