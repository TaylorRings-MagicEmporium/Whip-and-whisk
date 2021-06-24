using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUISwap : MonoBehaviour {

    public Animator CanvasAnimator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            CanvasAnimator.SetBool("continue",!CanvasAnimator.GetBool("continue"));
        }
	}
}
