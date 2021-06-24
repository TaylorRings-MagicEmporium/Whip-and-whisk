using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralTargetScript : MonoBehaviour {

    Animator Anim;
    public Transform player;

    Vector3 lookPos;
    //Quaternion rotation;

	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();
        StartCoroutine(Timer());
	}

    void Update()
    {
        //if (player)
        //{
        //    lookPos = player.position - transform.position;
        //    lookPos.y = 0;
        //    transform.rotation = Quaternion.LookRotation(lookPos);
        //    transform.Rotate(new Vector3(0, 90, 0));
        //}

        //transform.LookAt(new Vector3(0f, player.transform.position.y, 0f));
    }


    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            Anim.SetBool("EndTime", true);
            yield return new WaitForSeconds(Random.Range(3, 6));
            Anim.SetTrigger("Reset");
            Anim.SetBool("EndTime", false);
        }


    }
}
