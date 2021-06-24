using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leSpinUI : MonoBehaviour {

    RectTransform RT;
    public float multiplyer;

	// Use this for initialization
	void Start () {
        RT = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        RT.Rotate(new Vector3(0f, 0f, -1f) * Time.deltaTime * multiplyer);
	}
}
