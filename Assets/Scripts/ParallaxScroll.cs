using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour {

    [SerializeField]
    Transform cameraPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        FollowCamera();
	}

    public void FollowCamera()
    {
        //Once you attach script to the object, drag camera into the cameraPos value.
        Vector3 newPos = cameraPos.position;
        newPos.z = transform.position.z;
        newPos.y = transform.position.y;
        transform.position = newPos;
    }
}
