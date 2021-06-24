using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActTrig : MonoBehaviour {

    Animator Anim;
    public string TriggerName;
    public bool SetTrig = false;
    public GameObject PS;

	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();

        StartCoroutine(Die());

        
	}
	
	// Update is called once per frame

    IEnumerator Die()
    {
        yield return new WaitForSeconds(2);
        Anim.SetTrigger(TriggerName);
        yield return new WaitForSeconds(0.3f);
        Instantiate(PS, transform.position, Quaternion.identity).transform.Rotate(new Vector3(-90, 0, 0));
    }
}
