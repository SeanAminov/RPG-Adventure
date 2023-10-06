using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 movement;

    public LayerMask solidObjectsLayer;

    private bool isMoving = true;
    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
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

    private void Attack()
    {
        animator.SetTrigger("BowAttack");
    }

    public void LockMovement()
    {
        isMoving = false;
    }

    public void UnlockMovement()
    {
        isMoving = true;
    }
}
