using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    public Health playerHealth;

    public float distanceBetween;
    private float distance;

    private float lastAttackTime;
    private float attackDelay = 2f;
    private float attackRange = 2f;


    private Animator animator;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        


        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            animator.SetBool("SlimeMove", true);

            // Check if player is left or right
            if (player.transform.position.x < transform.position.x)
            {
                // Player is left, flip sprite to face left
                spriteRenderer.flipX = false;
            }
            else
            {
                // Player is right, flip sprite to face right
                spriteRenderer.flipX = true;
            }

            if (Time.time - lastAttackTime > attackDelay)
            {
                if (distance < attackRange)
                {
                    animator.SetTrigger("SlimeAttack");
                    lastAttackTime = Time.time;
                    playerHealth.TakeDamage(1); // Move when not getting stuck
                }
            }

        }
        else
        {
            animator.SetBool("SlimeMove", false);
        }






    }

}
