using UnityEngine;
public class PlayerMovement : MonoBehaviour
{

<<<<<<< Updated upstream
        private float jumpForce = 5.0f;
        public LayerMask groundLayer;
        public Transform groundCheck;
        public float groundDistance = 0.4f;
        private bool isGrounded;
        private Rigidbody rb;
        public float mouseSensitivity = 200.0f;
        public Transform playerBody;
        float xRotation = 0.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

=======
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    [Header("Camera Settings")]
    public Transform cameraPivot;   // Assign CameraPivot here in Inspector
    public float mouseSensitivity = 2f;

    private CharacterController controller;
    private Vector3 velocity;
    private float pitch = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
>>>>>>> Stashed changes
    }

    void Update()
    {
<<<<<<< Updated upstream


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); // reset Y velocity
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 2);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * 2);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 2);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 2);
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerBody.Rotate(Vector3.up * mouseX);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
    }
=======
        HandleMovement();
        HandleCameraLook();
    }

    void HandleMovement()
    {
        // WASD movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = transform.right * h + transform.forward * v;
        controller.Move(move * moveSpeed * Time.deltaTime);




        // Ground check
        if (IsGrounded() && velocity.y < 0)
        velocity.y = -2f;

        if (Input.GetButtonDown("Jump") && IsGrounded())
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);


        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleCameraLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate player (yaw)
        transform.Rotate(Vector3.up * mouseX);

        // Rotate camera (pitch)
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -80f, 80f);
        cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
    
    bool IsGrounded()
    {
    return Physics.Raycast(transform.position, Vector3.down, controller.height / 2 + 0.1f);
    }


>>>>>>> Stashed changes
}
