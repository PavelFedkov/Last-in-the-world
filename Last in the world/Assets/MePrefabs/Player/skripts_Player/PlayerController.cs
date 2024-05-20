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
        Vector3 Ver = new Vector3(-v, 0, 0);

        if (Physics.CheckSphere(groundCheckerTransform.position, 0.4f, groundLayer))
        {
            animator.SetBool("isinAir", false);

            if (-h == Vector3.ClampMagnitude(Hor, 1).magnitude)
                animator.SetFloat("PlayerMoveSpeed", -Vector3.ClampMagnitude(Hor, 1).magnitude);
            else if (h == Vector3.ClampMagnitude(Hor, 1).magnitude)
                animator.SetFloat("PlayerMoveSpeed", Vector3.ClampMagnitude(Hor, 1).magnitude);

            animator.SetFloat("PlayerMoveStrafe", Vector3.ClampMagnitude(Ver, 1).magnitude);

            Vector3 movDirZ = Vector3.ClampMagnitude(Hor, 1) * Speed;
            Vector3 movDirX = Vector3.ClampMagnitude(Ver, 1) * Speed;
            Rigidbody.velocity = new Vector3(movDirX.x, Rigidbody.velocity.y, movDirZ.z);
            Rigidbody.angularVelocity = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetKey(KeyCode.LeftAlt))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * 30f);
            }
        }
        else
        {
            animator.SetBool("isinAir", true);
        }

        transform.Rotate(0, -Input.GetAxis("Mouse Y") * rotationSpeedMouse, 0);

    }

    
    void Jump()
    {

        animator.SetTrigger("jump");
        Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }
}
