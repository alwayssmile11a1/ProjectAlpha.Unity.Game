using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed = 5f;
    public float rotationSpeed = 5f;
    


    private Rigidbody rgbd;
    private Vector3 movement = new Vector3();
    private int groundMask;
    private float camRayLength = 100f;
    private float xAxisMovement;
    private float zAxisMovement;
    private Camera cam;
    private Animator animator;
    private Vector3 lookDirection;

    // Use this for initialization
    private void Awake () {
        rgbd = GetComponent<Rigidbody>();
        groundMask = LayerMask.GetMask("Ground");
        cam = Camera.main;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	private void Update () {
        //Get axis
        xAxisMovement = Input.GetAxisRaw("Horizontal");
        zAxisMovement = Input.GetAxisRaw("Vertical");

        
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
        Animate();
    }

    //Move the character
    private void Move()
    {
        movement.Set(xAxisMovement, 0, zAxisMovement);
        //movement = movement.normalized;
        rgbd.MovePosition(transform.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    //Rotatate the character
    private void Turn()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit groundHit;

        if(Physics.Raycast(camRay, out groundHit, camRayLength, groundMask))
        {
            //calculate direction from character to the hitting position
            lookDirection = (groundHit.point - transform.position).normalized;
            lookDirection.y = 0f;

            //Calculate desired rotation
            Quaternion desiredRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0, lookDirection.z));
            //interpolate smoothly between current rotation and desiredRotation
            //rgbd.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.fixedDeltaTime * rotationSpeed);
            rgbd.MoveRotation(desiredRotation);
        }


    }

    //Animating the character
    private void Animate()
    {
        bool walking = xAxisMovement != 0 || zAxisMovement != 0;

        //Reset to idle animation
        animator.SetBool("WalkBack", false);
        animator.SetBool("Walk", false);

        if (walking)
        {
            if ((zAxisMovement < 0 && lookDirection.z > 0) || (zAxisMovement > 0 && lookDirection.z < 0))
            {
                animator.SetBool("WalkBack", true);
            }
            else
            {
                animator.SetBool("Walk", true);
            }

        }

        ////Reset to idle animation
        //animator.SetBool("WalkBack", false);
        //animator.SetBool("Walk", false);
        //animator.SetBool("WalkRight", false);
        //animator.SetBool("WalkLeft", false);

        //if (zAxisMovement!= 0)
        //{
        //    if ((zAxisMovement < 0 && lookDirection.z > 0) || (zAxisMovement > 0 && lookDirection.z < 0))
        //    {
        //        animator.SetBool("WalkBack", true);
        //    }
        //    else
        //    {
        //        animator.SetBool("Walk", true);
        //    }

        //}
        //else
        //{
        //    if(xAxisMovement != 0)
        //    {
        //        if (xAxisMovement > 0)
        //        {
        //            animator.SetBool("WalkRight", true);
        //        }
        //        else
        //        {
        //            animator.SetBool("WalkLeft", true);
        //        }
        //    }
        //}
    }





}
