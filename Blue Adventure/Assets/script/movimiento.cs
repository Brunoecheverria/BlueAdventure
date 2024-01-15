using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movimiento : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float speed;
    [SerializeField] private float speedCorrer;
    [Header("Jump")]
    [SerializeField] private float sphereRadius = 0.3f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] private float gravity = -9.8f;
    [Header("Controler")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private GameObject Maps;
    [SerializeField] private GameObject CamMaps;
    private bool Map = false;
    private Vector3 moveInput;
    private Vector3 velocity;
    private float Horizontal;
    private float Vertical;
    private bool isGrounded;
    private bool moviendo;
    Animator ani;




    private void Start()
    {
        ani = GetComponent<Animator>();
    }


    void Update()
    {




        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        moveInput = transform.right * Horizontal + transform.forward * Vertical;

        if (Input.GetKeyDown(KeyCode.M) && Map == false)
        {
            CamMaps.SetActive(true);
            Map = true;
            Maps.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.M) && Map == true)
        {
            CamMaps.SetActive(false);
            Maps.SetActive(false);
            Map = false;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetBool("salto", true);
        }
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetBool("salto", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            moviendo = true;
            ani.SetFloat("x", 1f);

        }
        if (!Input.GetKey(KeyCode.W))
        {
            moviendo = false;
            ani.SetFloat("x", 0f);
            ani.SetFloat("correr", 0);

        }
        if (Input.GetKey(KeyCode.S))
        {
            ani.SetFloat("x", -1f);

        }
        if (Input.GetKey(KeyCode.D))
        {
            ani.SetFloat("y", 1f);

        }
        if (!Input.GetKey(KeyCode.D))
        {
            ani.SetFloat("y", 0f);

        }
        if (Input.GetKey(KeyCode.A))
        {
            ani.SetFloat("y", -1f);

        }
        if (Input.GetButtonDown("Fire1"))
        {
            ani.SetBool("Disparar", true);
            //dfgdrf
        }
        if (!Input.GetButtonDown("Fire1"))
        {
            ani.SetBool("Disparar", false);

        }
        if (Input.GetKey(KeyCode.LeftShift) && moviendo == true)
        {
            ani.SetFloat("correr", 2);
        }
        if (!Input.GetKey(KeyCode.LeftShift) && moviendo == true)
        {
            ani.SetFloat("correr", 0);
        }
    }
    private void FixedUpdate()
    {
        characterController.Move(moveInput * speed * Time.fixedDeltaTime);
        velocity.y += gravity * Time.fixedDeltaTime;
        characterController.Move(velocity * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && moviendo == true)
        {

            transform.position += transform.forward * speedCorrer * Time.fixedDeltaTime;
        }
    }
}
