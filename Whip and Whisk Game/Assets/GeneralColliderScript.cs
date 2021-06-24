using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralColliderScript : MonoBehaviour {

    //public GameObject parent;
    public Animator Anim;
    public UIManager UIM;

    void Start()
    {
        //parent = transform.parent.gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        Anim.SetTrigger("EndTimeHit");
        UIM.AddScore(20);
    }
}
