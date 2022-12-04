using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{

    public float maxX, maxY;
    public float minX, minY;

    private void FixedUpdate()
    {
        Move();
    }


    public override void Move()
    {

        if(rb.position.x>= maxX && moveDirection.x>0)
        {
            moveDirection.x = 0;
        }

        if (rb.position.y >= maxY && moveDirection.y > .1)
        {
            moveDirection.y = 0;
        }

        if (rb.position.x <= minX && moveDirection.x < 0)
        {
            moveDirection.x = 0;
        }
        if (rb.position.y <=minY && moveDirection.y < 0)
        { 
            moveDirection.y = 0;
        }

        rb.velocity = moveDirection * moveSpeed;
    }
}
