using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    //public ThrowProjectile TP;
    public GameObject PS;

	// Use this for initialization
	void Start () {
        transform.tag = "Throw";
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter()
    {
        Debug.Log("HIT");
        if (PS)
        {
            Instantiate(PS, transform.position, Quaternion.identity).AddComponent<OneShotParticle>();
        }

        //Physics.sph
        //TP.EndPoint(transform.position);
        Destroy(gameObject);

    }
}
