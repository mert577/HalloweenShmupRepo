using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    protected Rigidbody2D rb;

    public float projectileSpeed;
    public float projectileLifeTime;

    public int damage;

    public int projectileHealth;

    protected Vector2 direction;

    protected float lifeTime=0;

    public bool damagesOnStay;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
   // {
      //  if (collision.gameObject.CompareTag("Enemy"))
        //{
         //   collision.ga.GetComponent<EnemyHealth>().TakeDamage(damage, collision.contacts[0].point);

        //}
   // }


    void DamageTarget(EnemyHealth eh, Vector2 pos)
    {
        if (eh)
        {
            eh.TakeDamage(damage,pos);
            projectileHealth--;
            if (projectileHealth <= 0)
            {
                Destroy(this.gameObject);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
           var enemy= collision.gameObject.GetComponent<EnemyHealth>();
            DamageTarget(enemy, collision.ClosestPoint(transform.position));
        
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (!damagesOnStay)
        {
            return;
        }
        if (collision.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<EnemyHealth>();
            DamageTarget(enemy, collision.ClosestPoint(transform.position));

        }
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
