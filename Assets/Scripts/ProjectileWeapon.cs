using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{

    public float cooldown;

    float lastTimeShot;

    [SerializeField]
    Projectile projectile;


    public override void StartFire()
    {
        base.StartFire();
        lastTimeShot = -1;
    }



    private void Update()
    {
        if (isFiring)
        {
            if (Time.time >= lastTimeShot + cooldown)
            {
                Shoot();
            }
        }
       
    }


    void Shoot()
    {
        lastTimeShot = Time.time;

        Projectile p=  Instantiate(projectile, transform.position,Quaternion.identity);
        p.SetProjectileDirection(transform.right);
    }
}
