using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoEnemy : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private float sphereRadius;
    [SerializeField] private float gravity;
    [SerializeField] LayerMask groundMask;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform groundCheck;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        
    }

  
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }
    private void FixedUpdate()
    {
        velocity.y += gravity * Time.fixedDeltaTime;
        characterController.Move(velocity * Time.fixedDeltaTime);
    }
}
