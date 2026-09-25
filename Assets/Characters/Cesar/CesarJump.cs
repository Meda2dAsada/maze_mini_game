using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class CesarJump : MonoBehaviour
{
    public float jumpForce = 5f;

    private Rigidbody body;
    private BoxCollider boxCollider;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        // Jump with Space only when the cube is on the ground.
        if (Keyboard.current == null || !Keyboard.current.spaceKey.wasPressedThisFrame)
            return;

        if (body.linearVelocity.y > 0.1f) return;

        Bounds bounds = boxCollider.bounds;
        if (Physics.Raycast(bounds.center, Vector3.down, out RaycastHit hit,
            bounds.extents.y + 0.05f, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore)
            && hit.normal.y > 0.5f)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
