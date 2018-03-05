using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

    public WeaponSO weapon;
    public GameObject weaponHolder;

    private float timer = 0;

    private void Awake()
    {
        weapon.Initialize(weaponHolder);
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;


        if (Input.GetKey(KeyCode.Mouse0) && timer > 1 / weapon.fireRate)
        {
            Shoot();

            timer = 0;
        }

    }

    void Shoot()
    {
        weapon.Fire();

    }


}
