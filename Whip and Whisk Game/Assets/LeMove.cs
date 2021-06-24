using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeMove : MonoBehaviour {

    public List<GameObject> placemarks;

    public float speed = 1;
    public int counter = 0;
	// Use this for initialization
	void Start () {
        transform.position = placemarks[counter].transform.position;
        transform.LookAt(placemarks[counter].transform);
    }
	
	// Update is called once per frame
	void Update () {
        if((placemarks[counter].transform.position - transform.position).sqrMagnitude < 1f)
        {
            counter++;

        }
        if(counter == placemarks.Count)
        {
            counter = 0;
            transform.position = placemarks[counter].transform.position;
        }
        transform.LookAt(placemarks[counter].transform);
        transform.position += (placemarks[counter].transform.position - transform.position).normalized * Time.deltaTime * speed;
    }

}
