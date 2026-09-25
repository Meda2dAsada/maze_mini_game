using UnityEngine;
using UnityEngine.InputSystem;

public class CubeJump : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 5f;

    private Rigidbody body;
    private Vector3 movement;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement = Vector3.zero;
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard.wKey.isPressed) movement.z += 1;
        if (keyboard.sKey.isPressed) movement.z -= 1;
        if (keyboard.aKey.isPressed) movement.x -= 1;
        if (keyboard.dKey.isPressed) movement.x += 1;
        movement = movement.normalized;

        bool grounded = Physics.Raycast(transform.position, Vector3.down, 0.6f);
        if (keyboard.spaceKey.wasPressedThisFrame && grounded && body.linearVelocity.y <= 0.1f)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        body.linearVelocity = new Vector3(movement.x * moveSpeed,
            body.linearVelocity.y, movement.z * moveSpeed);
    }
}
