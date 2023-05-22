using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private FixedJoystick _joystick;

    [SerializeField] private float _moveSpeed;
    private Animator animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.freezeRotation = true; // Add this line to freeze rotation
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float horizontalMovement = _joystick.Horizontal;
        float verticalMovement = _joystick.Vertical;

        Vector2 movement = new Vector2(horizontalMovement, verticalMovement) * _moveSpeed;
        _rigidbody.velocity = movement;

        // Set animation parameters
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
