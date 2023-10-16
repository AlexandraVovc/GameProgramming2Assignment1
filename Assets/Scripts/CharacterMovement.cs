using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{

    public Vector3 gravity;
    public Vector3 playerVelocity;

    public bool isOnGround = false;
    public float gravityValue = -9.81f;

    public float walkSpeed = 5;
    public float runSpeed = 8;
    public bool groundedPlayer;
    private float jumpHeight = 1f;
    public bool canDoubleJump = false;

    public static int buildIndex;

    private CharacterController controller;
    private Animator animator;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    public void Update()
    {
        ProcessMovement();
        FallOffPlane();
    }
    public void LateUpdate()
    {       
       UpdateAnimator();
      
    }
    void DisableRootMotion()
    {
        animator.applyRootMotion = false;  
    }
    void UpdateAnimator()
    {
        isOnGround = controller.isGrounded;

        Vector3 characterXandZMotion = new Vector3(playerVelocity.x, 0.0f, playerVelocity.z);

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.0f || Mathf.Abs(Input.GetAxis("Vertical"))>0.0f)
        {
            if (Input.GetButton("Fire3"))
            {
                animator.SetFloat("Speed", 1.0f);
            } else
            {
                animator.SetFloat("Speed", 0.5f);
            }
        } else
        {
            animator.SetFloat("Speed", 0.0f);
        }

        animator.SetBool("IsGrounded", isOnGround);

        animator.SetBool("DoesDoubleJump", canDoubleJump);

    }

    void ProcessMovement()
    { 
        float speed = GetMovementSpeed();
 
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (moveDirection != Vector3.zero)
        {
            gameObject.transform.forward = moveDirection;
        }

        Vector3 movement = moveDirection.normalized * speed * Time.deltaTime;
 
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            if (Input.GetButtonDown("Jump"))
            {
                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
            else
            {                           
                gravity.y = -1.0f;
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && canDoubleJump)
            {
                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                canDoubleJump = false;
            }
            gravity.y += gravityValue * Time.deltaTime;
        }
        playerVelocity = gravity * Time.deltaTime + movement;
        controller.Move(playerVelocity);
    }

    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }

    void FallOffPlane()
    {
        if (gameObject.transform.position.y <= -30)
        {
            switch (buildIndex)
            {
                case 2:
                    SceneManager.LoadScene("Level 1");
                    break;
                case 3:
                    SceneManager.LoadScene("Level 2");
                    break;
                default:
                    SceneManager.LoadScene("Level 3");
                    break;
            }
        }
    }
}
