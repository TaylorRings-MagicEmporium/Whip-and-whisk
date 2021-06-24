using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacter : MonoBehaviour {

    public float RotateSpeed;
    public float MovementSpeed;

    public Animator person;
    //public Animator gun;

    Rigidbody rb;
    public float UpForce;

    RaycastHit hit;
    bool OnGround;
    bool OnGroundBuffer;
    CapsuleCollider CC;

    public ThrowProjectile TP;
    public ThirdPersonGun TPG;

    private InputLoader IL;
    private int ILCounter;

    private List<InputLine> InputLog = new List<InputLine>();

    //public bool GunMode = true;



	// Use this for initialization
	void Start () {
        OnGround = true;
        OnGroundBuffer = false;

        CC = GetComponent<CapsuleCollider>();

        rb = GetComponent<Rigidbody>();

        IL = GetComponent<InputLoader>();
        if (IL)
        {
            InputLog = IL.InputLog;
        }
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMovement();
        //Debug.Log(InputLog[ILCounter].MouseClick0);
        if (person.GetBool("HasGun"))
        {
            PlayerShoot();
        } else
        {
            PlayerThrow();
        }

        if (IL)
        {
            ILCounter++;
        }


	}

    void PlayerMovement()
    {
        if (!IL)
        {
            OnGroundBuffer = OnGround;

            Physics.Raycast(transform.position, Vector3.down, out hit);

            if (Input.GetKeyDown(KeyCode.Space) && OnGround)
            {
                rb.AddForce(0, UpForce, 0);
                person.SetTrigger("jumpBegin");

                CC.center = new Vector3(0, 3.01f, 0);
                CC.height = 4.62f;
            }

            //Debug.Log(hit.distance);

            if (hit.distance < 5f)
            {
                OnGround = true;
            }
            else
            {
                OnGround = false;
            }

            if (!OnGroundBuffer && OnGround)
            {
                person.SetTrigger("jumpEnd");
                CC.center = new Vector3(0, 0.3221486f, 0);
                CC.height = 7.604297f;
            }

            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 PlayerRotate = new Vector3(0, hor, 0) * RotateSpeed * Time.deltaTime;
            Vector3 PlayerMovement = new Vector3(0f, 0f, ver) * MovementSpeed * Time.deltaTime;
            transform.Translate(PlayerMovement, Space.Self);
            transform.Rotate(PlayerRotate);

            if (ver > 0.2f)
            {
                // move
                person.SetBool("moveforward", true);
            }
            else if (ver < -0.2f)
            {
                person.SetBool("movebackward", true);
            }
            else
            {
                person.SetBool("moveforward", false);
                person.SetBool("movebackward", false);
                // idle
            }
        }
        else if(IL && ILCounter < InputLog.Count)
        {
            OnGroundBuffer = OnGround;

            Physics.Raycast(transform.position, Vector3.down, out hit);

            if (InputLog[ILCounter].space)
            {
                rb.AddForce(0, UpForce, 0);
                person.SetTrigger("jumpBegin");

                CC.center = new Vector3(0, 3.01f, 0);
                CC.height = 4.62f;
            }

            //Debug.Log(hit.distance);

            if (hit.distance < 5f)
            {
                OnGround = true;
            }
            else
            {
                OnGround = false;
            }

            if (!OnGroundBuffer && OnGround)
            {
                person.SetTrigger("jumpEnd");

                CC.center = new Vector3(0, 0.3221486f, 0);
                CC.height = 7.604297f;
            }

            float hor = InputLog[ILCounter].Horizontal;
            float ver = InputLog[ILCounter].Vertical;
            Vector3 PlayerRotate = new Vector3(0, hor, 0) * RotateSpeed * Time.deltaTime;
            Vector3 PlayerMovement = new Vector3(0f, 0f, ver) * MovementSpeed * Time.deltaTime;
            transform.Translate(PlayerMovement, Space.Self);
            transform.Rotate(PlayerRotate);

            if (ver > 0.2f)
            {
                // move
                person.SetBool("moveforward", true);
            }
            else if (ver < -0.2f)
            {
                person.SetBool("movebackward", true);
            }
            else
            {
                person.SetBool("moveforward", false);
                person.SetBool("movebackward", false);
                // idle
            }
        }

        

    }

    void PlayerShoot()
    {
        if (!IL)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //gun.SetTrigger("shoot");
                Debug.Log("shoot");
                TPG.Shoot();
            }
        }
        else if(IL && ILCounter < InputLog.Count)
        {
            if (InputLog[ILCounter].MouseClick0)
            {
                //gun.SetTrigger("shoot");
                Debug.Log("shoot");
                TPG.Shoot();
            }
        }

    }

    void PlayerThrow()
    {
        if (!IL)
        {
            if (Input.GetMouseButtonDown(0))
            {
                person.SetTrigger("Throw");
                Debug.Log("Throw");
                TP.BeginThrow();
            }
        }
        else if(IL && ILCounter < InputLog.Count)
        {
            if (InputLog[ILCounter].MouseClick0)
            {
                person.SetTrigger("Throw");
                Debug.Log("Throw");
                TP.BeginThrow();
            }
        }

    }
}

