using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RodrigoMovement : MonoBehaviour
{
  
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;

   
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        
        Vector3 move = transform.right * x + transform.forward * z;

        
        controller.Move(move * currentSpeed * Time.deltaTime);

       
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}