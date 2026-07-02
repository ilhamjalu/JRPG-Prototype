using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] Animator animator;
    [SerializeField] SpriteFlip spriteFlip;

    public bool canMove;

    // Update is called once per frame
    void Update()
    {
        if(canMove) MovementInput();
    }

    public void MovementInput()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        transform.position += (Vector3)input * speed * Time.deltaTime;

        spriteFlip.Flip(input.x);

        animator.SetBool("IsWalk", input != Vector2.zero);
    }

    public void DisableMove()
    {
        canMove = false;
    }

    public void EnableMove()
    {
        canMove = true;
    }
}
