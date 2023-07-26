using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform weaponHold;
    public Gun startingGun;
    Gun equipGun;

    private void Start()
    {
        if(startingGun != null)
        {
            EquipGun(startingGun);
        }
    }
    public void EquipGun(Gun gunToEquip)
    {
        if (equipGun != null)
        {
            Destroy(equipGun.gameObject);
        }
        equipGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;
        equipGun.transform.parent = weaponHold;
    }

    internal void Shot()
    {
        if(equipGun !=null)
        {
            equipGun.Shoot();
        }
    }
}
