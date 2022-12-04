using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health;

    public int maxHealth;

    public bool invincible;

    public float invincibilityTime;


    GraphicsController gfx;

    private void Awake()
    {
        gfx = GetComponent<GraphicsController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int damage, Vector2 pos)
    {

        if (invincible)
        {
            return;
        }



        StartCoroutine(Invincibility());

        gfx.DamageAnimation(pos);


        health -= damage;

        if (health <= 0)
        {
            Death();
        }
        IEnumerator Invincibility()
        {
            invincible = true;
            yield return new WaitForSecondsRealtime(invincibilityTime);
            invincible = false;
        }
    }

   


    void Death()
    {
        gfx.DeathAnimation();


        Destroy(this.gameObject, 1f);
       
    }

}
