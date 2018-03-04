using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = 5;

    private Vector3 cameraOffset;

    private void Start()
    {
        //calculate camera offset
        cameraOffset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate () {

        // transform.LookAt(target.position);
        transform.position = Vector3.Lerp(transform.position, target.position + cameraOffset, Time.deltaTime * smoothSpeed);


	}
}
