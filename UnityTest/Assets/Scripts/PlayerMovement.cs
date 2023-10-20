using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintMultiplier = 1f;

    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 movement;

    public LayerMask solidObjectsLayer;

    private bool isMovingUp = true;
    private bool isMovingDown = true;
    private bool isMovingLeft = true;
    private bool isMovingRight = true;

    private bool isRunning = false;
    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift)) // Check if LeftShift is pressed
        {
            // movement *= sprintMultiplier; // Apply sprint multiplier
            isRunning = !isRunning;
        }

       
        animator.SetBool("RunningLeft", isRunning);




        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetMouseButtonDown(0))
        {
            if (movement.x > 0)
            {
                animator.SetTrigger("AttackRight");
            }
            else if (movement.x < 0)
            {
                animator.SetTrigger("AttackLeft");
            }
            else if (movement.y > 0)
            {
                animator.SetTrigger("AttackUp");
            }
            else if (movement.y < 0)
            {
                animator.SetTrigger("AttackDown");
            }
        }
    }

    private void FixedUpdate()
    {
        if (isRunning)
        {
            movement *= sprintMultiplier;
        }
        if (isMovingUp && isMovingDown && isMovingLeft && isMovingRight)
        {


            var targetPos = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
            if (IsWalkable(targetPos))
            {
                rb.MovePosition(targetPos);
            }
        }

    }

    private bool IsWalkable(Vector2 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.5f, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }


    public void UpMovementLock()
    {
        isMovingUp = false;
    }

    public void UpUnlockMovement()
    {
        isMovingUp = true;
    }

    public void DownMovementLock()
    {
        isMovingDown = false;
    }

    public void DownUnlockMovement()
    {
        isMovingDown = true;
    }
    public void LeftMovementLock()
    {
        isMovingLeft = false;
    }

    public void LeftUnlockMovement()
    {
        isMovingLeft = true;
    }
    public void RightMovementLock()
    {
        isMovingRight = false;
    }

    public void RightUnlockMovement()
    {
        isMovingRight = true;
    }
}
