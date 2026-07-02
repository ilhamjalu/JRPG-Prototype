using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlip : MonoBehaviour
{
    public void Flip(float moveDirection)
    {
        if (moveDirection != 0)
        {
            GetComponent<SpriteRenderer>().flipX = moveDirection < 0;
        }
    }
}
