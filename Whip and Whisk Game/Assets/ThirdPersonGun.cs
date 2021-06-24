using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonGun : MonoBehaviour {

    public Transform ShootingTransform;
    public GameObject bullet;
    public Camera main;

    public float GlobalDistance = 25;
    public float GlobalSpeed = 1;

    GameObject activeBullet;


    void Start()
    {
        //main = Camera.main;
    }
    void Update()
    {
        ShootingTransform.rotation.SetLookRotation(main.transform.forward);
    }

    public void Shoot()
    {
        activeBullet = Instantiate(bullet, ShootingTransform.position, ShootingTransform.rotation);
        activeBullet.AddComponent<Bullet>();
        activeBullet.GetComponent<Bullet>().distance = GlobalDistance;
        activeBullet.GetComponent<Bullet>().speed = GlobalSpeed;
        activeBullet.GetComponent<Bullet>().direction = main.transform.forward;

    }

}
