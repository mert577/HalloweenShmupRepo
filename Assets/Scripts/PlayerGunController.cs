using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{

    [SerializeField]
    List<Weapon> weapons;

    [SerializeField]
    GameObject gunHolder;


    void UpdateWeaponsList()
    {
        weapons = new List<Weapon>(gunHolder.GetComponentsInChildren<Weapon>());
    }

    private void Start()
    {
        UpdateWeaponsList();
    }

    public void StartFire()
    {
        Debug.Log("I've started firing!!!");


        foreach(Weapon weapon in weapons)
        {
            weapon.StartFire();
        }
    }


    public void StopFire()
    {
        Debug.Log("I've stopped firing!!!");

        foreach (Weapon weapon in weapons)
        {
            weapon.StopFire();
        }
    }
}
