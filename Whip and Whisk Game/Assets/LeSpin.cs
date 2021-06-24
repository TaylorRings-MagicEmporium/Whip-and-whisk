using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeSpin : MonoBehaviour {

    Transform Gametransform;
    public float multiplier = 1;
    // Use this for initialization
    void Start () {
        Gametransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Gametransform.Rotate(new Vector3(0f, 0f, 1f) * Time.deltaTime * multiplier);
	}
}
