using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangProjectile : Projectile
{

    [SerializeField]

    AnimationCurve speedCurve;


    public override void ProjectileMove()
    {
        rb.velocity = direction * projectileSpeed* speedCurve.Evaluate(lifeTime);
    }


}
