using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhichSit : MonoBehaviour {

    Animator Anim;

	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();

        Anim.SetInteger("WhichSit", Random.Range(0, 3));

        if(Random.Range(0,2) == 1)
        {
            Anim.SetBool("Mirror", true);
        }
        else
        {
            Anim.SetBool("Mirror", false);
        }


    }
	

}
