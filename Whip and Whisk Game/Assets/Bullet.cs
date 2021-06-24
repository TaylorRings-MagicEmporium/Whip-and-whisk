using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float distance;
    public Vector3 direction;
    Vector3 StartingPoint;

    public float speed = 1;

    float counter;

	// Use this for initialization
	void Start () {
        StartingPoint = transform.position;
        transform.tag = "Bullet";
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(StartingPoint, StartingPoint + direction * distance, counter);
        counter += Time.deltaTime * speed;
        if(counter > 1)
        {
            Destroy(gameObject);
        }
        //if()
	}
}
