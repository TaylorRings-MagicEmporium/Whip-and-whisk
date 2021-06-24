using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonCameraLook : MonoBehaviour {

    public Transform MainCamera;
    Vector3 LookingPoint;
    Vector3 WorldPoint;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //lookingPoint = new Vector3(Input.mousePosition.x,Input.mousePosition.y,)
        WorldPoint = MainCamera.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        //MainCamera.forward = WorldPoint - transform.position;

        MainCamera.LookAt(WorldPoint);
	}
}
