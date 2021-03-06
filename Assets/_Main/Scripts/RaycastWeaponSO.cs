﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Weapon/RaycastWeapon", order = 1)]
public class RaycastWeaponSO : WeaponSO {

    public Gradient laserColor;
    private RaycastShootTriggerable rcShooter;


    public override void Initialize(GameObject gameObject)
    {
        rcShooter = gameObject.GetComponent<RaycastShootTriggerable>();

        if (rcShooter == null) return;

        rcShooter.range = range;
        rcShooter.laserColor = laserColor;


        rcShooter.Initialize();

    }
    public override void Fire()
    {
        if (rcShooter != null)
        {
            rcShooter.Fire();
        }
    }

}
