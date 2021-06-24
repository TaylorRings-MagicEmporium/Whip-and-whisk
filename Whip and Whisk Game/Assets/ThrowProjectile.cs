using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowProjectile : MonoBehaviour {

    public GameObject ObjectToThrow;
    public GameObject BeginningPoint;
    public Camera main;
    public ParticleSystem DeathParticles;

    private GameObject ThrownObject;

    public float power;
    Vector3 direction;

    void Start()
    {
        main = Camera.main;
        
    }

    void Update()
    {

    }

    public void BeginThrow()
    {
        direction = main.transform.forward.normalized;
        ThrownObject = Instantiate(ObjectToThrow, BeginningPoint.transform.position, Quaternion.identity);
        ThrownObject.transform.localScale = new Vector3(50, 50, 50);
        ThrownObject.AddComponent<Rigidbody>();
        ThrownObject.AddComponent<Projectile>();
        ThrownObject.GetComponent<Projectile>().PS = DeathParticles.gameObject;
        ThrownObject.GetComponent<Rigidbody>().mass = 0.01f;
        ThrownObject.GetComponent<Rigidbody>().AddForce(direction * power);
    }
}
