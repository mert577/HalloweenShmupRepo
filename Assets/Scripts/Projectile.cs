using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    protected Rigidbody2D rb;

    public float projectileSpeed;
    public float projectileLifeTime;




    protected Vector2 direction;

    protected float lifeTime=0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        Initilize();
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

    private void Update()
    {
        lifeTime += Time.deltaTime;
    }

    public virtual void Initilize()
    {
        TimeOutDestroy();
    }

    public void TimeOutDestroy()
    {
        Destroy(this.gameObject,projectileLifeTime);

    }
}
