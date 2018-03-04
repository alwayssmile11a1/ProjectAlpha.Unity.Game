using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public float velocity = 5f;
    public float rotationSpeed = 5f;
    public Camera cam;


    //reference to rigidbody
    private Rigidbody rgbd;

    private Vector3 movement;


	// Use this for initialization
	private void Start () {
        rgbd = GetComponent<Rigidbody>();
        movement = new Vector3();
	}
	
	// Update is called once per frame
	private void Update () {

        //The movement
        float xAxisMovement = Input.GetAxis("Horizontal");
        float zAxisMovement = Input.GetAxis("Vertical");

        movement.Set(xAxisMovement, 0, zAxisMovement);


        
        //Rotate the character
        
        //calculate direction from character to the mouse position
        Vector3 direction = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10)) - transform.position;

        Quaternion desiredQuaternion = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation,desiredQuaternion ,Time.deltaTime * rotationSpeed);


	}

    private void FixedUpdate()
    {
        rgbd.MovePosition(rgbd.position + movement * velocity * Time.fixedDeltaTime);
    }


}
