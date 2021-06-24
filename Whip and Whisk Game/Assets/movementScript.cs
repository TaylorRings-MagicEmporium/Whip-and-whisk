using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour {

    Rigidbody rb;
    public float speed = 1;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("forward");
            transform.Translate(transform.forward);
        } else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("left");
            transform.Rotate(new Vector3(0, -1, 0));
        } else if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("backward");
            transform.Translate(-transform.forward);
        } else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("right");
            transform.Rotate(new Vector3(0, 1, 0));
        }
        else
        {
            //wrb.AddForce(-transform.forward.normalized * rb.velocity.sqrMagnitude);
        }
	}
}
