using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController Charcon;

    public Camera playerCamera;
    [SerializeField] private float movementspeed = 6f;
    [SerializeField] private float jumpforce = 5f;
    [SerializeField] private float runspeed = 10f;
    [SerializeField] private float lookspeed = 2f;

    [SerializeField] private float gravity = -20f;
    private float yVelocity;

    private Vector2 turn;

    void Start()
    {
        Charcon = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        if (playerCamera == null)
            playerCamera = Camera.main;
    }

    void Update()
    {
        // --- CAMERA ROTATION ---
        turn.x += Input.GetAxis("Mouse X") * lookspeed;
        turn.y += Input.GetAxis("Mouse Y") * lookspeed;
        turn.y = Mathf.Clamp(turn.y, -80f, 80f);

        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        playerCamera.transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);

        // --- MOVEMENT ---
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

        forward.y = 0;
        right.y = 0;

        Vector3 move = forward.normalized * moveVertical + right.normalized * moveHorizontal;

        float currentSpeed = Input.GetKey(KeyCode.Q) ? runspeed : movementspeed;

        Charcon.Move(move * currentSpeed * Time.deltaTime);

        
        if (Charcon.isGrounded)
        {
            if (yVelocity < 0)
                yVelocity = -2f;
                Debug.Log(Charcon.isGrounded); 

            if (Input.GetKeyDown(KeyCode.Space))
                yVelocity = jumpforce;
        }

        yVelocity += gravity * Time.deltaTime;

        Charcon.Move(new Vector3(0, yVelocity, 0) * Time.deltaTime);
    }
}
