using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody Rigidbody;
    private Animator animator;
    public Transform groundCheckerTransform;
    public LayerMask groundLayer;
    public float rotationSpeed = 10f;
    public float rotationSpeedMouse = 6f;
    public float Speed = 10f;
    public float jumpForce = 5f;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Rigidbody.useGravity = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 directionVector = new Vector3(-v, 0, h);
        Vector3 Hor = new Vector3(0, 0, h);

        transform.Rotate(0, -Input.GetAxis("Mouse Y") * rotationSpeedMouse, 0);

        animator.SetFloat("PlayerMoveSpeed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
        Vector3 movDir = Vector3.ClampMagnitude(directionVector, 1) * Speed;
        Rigidbody.velocity = new Vector3(movDir.x, Rigidbody.velocity.y,movDir.z);
        Rigidbody.angularVelocity = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Physics.CheckSphere(groundCheckerTransform.position, 0.3f, groundLayer))
        {
            animator.SetBool("isinAir", false);
        }
        else
        {
            animator.SetBool("isinAir", true);
        }
        
        if (Input.GetKey(KeyCode.LeftAlt))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * 30f);


    }

    
    void Jump()
    {
        RaycastHit hit;
        if (Physics.CheckSphere(groundCheckerTransform.position, 0.3f, groundLayer))
        {
            animator.SetTrigger("jump");
            Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
}
