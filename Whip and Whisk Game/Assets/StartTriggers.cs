using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTriggers : MonoBehaviour {

    public Animator Anim;

    public bool start;

    public bool stop;

    void Start()
    {
        //Anim = GetComponent<Animator>();


    }

    void Update()
    {
        if (start)
        {
            Anim.SetTrigger("start");
        }

        if (stop)
        {
            Anim.SetTrigger("stop");
        }
    }
}
