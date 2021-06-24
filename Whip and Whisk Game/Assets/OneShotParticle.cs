using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotParticle : MonoBehaviour {

    public ParticleSystem PS;

	// Use this for initialization
	void Start () {
        PS = GetComponent<ParticleSystem>();
        PS.Play();
	}
	
	// Update is called once per frame
	void Update () {

        if (PS)
        {
            if (!PS.IsAlive())
            {
                Destroy(gameObject);
            }
        }
	}
}
