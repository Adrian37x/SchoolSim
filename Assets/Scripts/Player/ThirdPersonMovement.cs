using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonMovement : MonoBehaviour
{
    public Transform cam;
    public Animator animator;
    CharacterController controller;

    public float speed = 6f;
    public float gravity = -9.81f;

    public float turnSmoothTime = .1f;
    float turnSmoothVelocity;

    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    void Start()
	{
        controller = GetComponent<CharacterController>();
	}

    void Update()
    {
        Vector3 direction = GetInputDirection();
        UpdateAnimation(direction);

        if (direction.magnitude >= .1f)
		{
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
		}

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
		{
            velocity.y = -2f;
		}

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private Vector3 GetInputDirection()
	{
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        return new Vector3(horizontal, 0f, vertical).normalized;
    }

    private void UpdateAnimation(Vector3 direction)
	{
        animator.SetFloat("magnitude", direction.magnitude);
    }
}
