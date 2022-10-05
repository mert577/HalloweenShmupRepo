using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Rigidbody2D rb;

    public float projectileSpeed;

    Vector2 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public  void SetProjectileDirection(Vector2 _direction)
    {
        direction = _direction;
    }


    public virtual void ProjectileMove()
    {
        rb.velocity = direction*projectileSpeed;
    }

    private void FixedUpdate()
    {
        ProjectileMove();
    }
}
