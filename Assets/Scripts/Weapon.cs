using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public bool isFiring;


    public virtual void StartFire()
    {
        isFiring = true;

    }


    public virtual void StopFire()
    {
        isFiring = false;
    }
   
}
