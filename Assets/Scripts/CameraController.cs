using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    Transform objectToFollow;

    [SerializeField]
    float cameraFollowSpeed = 5;

    [SerializeField]
    float xOffset;
    [SerializeField]
    float yOffset;

    [SerializeField]
    float xBoundary;
    [SerializeField]
    float yBoundary;
    [SerializeField]
    Transform xBoundaryX;
    [SerializeField]
    Transform yBoundaryY;
    //ALSO set upper and lower bounds

    float zOffset = -10;
	// Use this for initialization
	void Start ()
    {
        xBoundary = xBoundaryX.position.x;
        yBoundary = yBoundaryY.position.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 newPosition = new Vector3(objectToFollow.position.x + xOffset, objectToFollow.position.y + yOffset, zOffset);
        transform.position = Vector3.Lerp(transform.position, newPosition, cameraFollowSpeed*Time.deltaTime);

        if (transform.position.x < xBoundary)
        {
            transform.position = new Vector3(xBoundary, transform.position.y, transform.position.z);
        }

        if (transform.position.y < yBoundary)
        {
            transform.position = new Vector3(transform.position.x, yBoundary, transform.position.z);
        }
    }
}
