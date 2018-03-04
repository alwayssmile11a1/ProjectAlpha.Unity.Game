using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

    public float fireRate = 5f;
    public float range = 100f;
    public LineRenderer laserRenderer;
    public Transform shootTransform;



    private float timer = 0;
    private float effectDisplayTime = 0.02f;
    private RaycastHit hit = new RaycastHit();
    private Ray shootRay = new Ray();
    private int shootableMask;

	// Use this for initialization
	void Awake () {
        shootableMask = LayerMask.GetMask("Shootable");
        laserRenderer.useWorldSpace = true;
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;


        if (Input.GetKey(KeyCode.Mouse0) && timer > 1/fireRate)
        {
            Shoot();

            timer = 0;
        }

        if(timer >= effectDisplayTime)
        {
            DisableEffects();
        }


	}

    void DisableEffects()
    {
        laserRenderer.enabled = false;

    }


    void Shoot()
    {
        //setup laser line
        laserRenderer.enabled = true;
        laserRenderer.SetPosition(0, shootTransform.position);

        shootRay.origin = shootTransform.position;
        shootRay.direction = shootTransform.forward;


        if(Physics.Raycast(shootRay,out hit, range, shootableMask))
        {

        }
        else
        {
            laserRenderer.SetPosition(1,shootRay.origin + shootRay.direction * range);

        }


    }


}
