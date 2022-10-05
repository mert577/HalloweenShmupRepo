using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{

    private void FixedUpdate()
    {
        Move();
    }


    public override void Move()
    {
        rb.velocity = moveDirection * moveSpeed;
    }
}
