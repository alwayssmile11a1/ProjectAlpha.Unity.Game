using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Weapon/RaycastWeapon", order = 1)]
public class RaycastWeaponSO : WeaponSO {

    public Gradient laserColor;
    private RaycastShootTriggerable rcShooter;


    public override void Initialize(GameObject gameObject)
    {
        rcShooter = gameObject.GetComponent<RaycastShootTriggerable>();

        rcShooter.fireRate = fireRate;
        rcShooter.range = range;
        rcShooter.laserColor = laserColor;


        rcShooter.Initialize();

    }
    public override void Fire()
    {

        rcShooter.Fire();

    }

}
