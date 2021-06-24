using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDirector : MonoBehaviour {

    public Animator person;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float ver = Input.GetAxis("Vertical");

        if (ver > 0.2f)
        {
            // move
            person.SetBool("moveforward", true);
        }
        else if(ver < -0.2f)
        {
            person.SetBool("movebackward", true);
        }
        else
        {
            person.SetBool("moveforward", false);
            person.SetBool("movebackward", false);
            // idle
        }
	}
}
