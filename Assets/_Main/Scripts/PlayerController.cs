using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float velocity = 5f;
    public float rotationSpeed = 5f;
    public Camera cam;
    


    //reference to rigidbody
    private Rigidbody rgbd;
    private Vector3 movement = new Vector3();
    private int groundMask;
    private float camRayLength = 100f;
    private float xAxisMovement;
    private float zAxisMovement;

    // Use this for initialization
    private void Awake () {
        rgbd = GetComponent<Rigidbody>();
        groundMask = LayerMask.GetMask("Ground");
	}
	
	// Update is called once per frame
	private void Update () {
        //The movement
        xAxisMovement = Input.GetAxisRaw("Horizontal");
        zAxisMovement = Input.GetAxisRaw("Vertical");
       

    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    //Move the character
    private void Move()
    {
        movement.Set(xAxisMovement, 0, zAxisMovement);
        //movement = movement.normalized;
        rgbd.MovePosition(transform.position + movement * velocity * Time.fixedDeltaTime);
    }

    //Rotatate the character
    private void Turn()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit groundHit;

        if(Physics.Raycast(camRay, out groundHit, camRayLength, groundMask))
        {
            //calculate direction from character to the hitting position
            Vector3 direction = (groundHit.point - transform.position).normalized;
            direction.y = 0f;

            //Calculate desired rotation
            Quaternion desiredRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            //interpolate smoothly between current rotation and desiredRotation
            //rgbd.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.fixedDeltaTime * rotationSpeed);
            rgbd.MoveRotation(desiredRotation);
        }


    }

}
