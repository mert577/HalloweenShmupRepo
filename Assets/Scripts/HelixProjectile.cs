using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixProjectile : Projectile
{
    public float helixRange;

    public float waveLength;

    public bool flipped;
    public override void ProjectileMove()
    {

        int flip = flipped ? -1 : 1;
        Vector2 newDir = Quaternion.Euler(0, 0,flip* Mathf.Sin(lifeTime * waveLength) * helixRange)* direction ;

        transform.rotation = Quaternion.Euler(0, 0, flip * Mathf.Sin(lifeTime * waveLength) * waveLength);

        rb.velocity =   newDir * projectileSpeed;
    }

}
