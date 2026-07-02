using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportCharacterController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float followDistance = 1.5f;
    
    private SpriteFlip spriteFlip; 
    private Animator animator;
    private Rigidbody2D rb;

    public bool canMove;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteFlip = GetComponent<SpriteFlip>();
    }

    private void Update()
    {
        if(canMove) FollowPlayer();
    }

    void FollowPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        bool isWalking = distance > followDistance;
        animator.SetBool("IsWalk", isWalking);

        if (!isWalking)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        spriteFlip.Flip(direction.x);
    }
}
