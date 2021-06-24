using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    private const float Y_ANGLE_MIN = -50.0f;
    private const float Y_ANGLE_MAX = 25.0f;

    public Transform lookAt;
    public Vector3 lookAtOffset;
    public Vector3 offset2;
    private Vector3 CurrentLook;
    public Transform camTransform;

    public Camera cam;

    private float distance = 10.0f;
    //private float currentX = 0.0f;
    private float currentY = 0.0f;
    //private float sensivityX = 4.0f;
    //private float sensivityY = 1.0f;

    public bool HadDied = false;

    private float counter;

    private Vector3 velocity = Vector3.zero;

    public InputLoader IL;
    private int ILCounter;

    private List<InputLine> InputLog = new List<InputLine>();


    // Use this for initialization
    void Start () {
        camTransform = transform;
        //cam = Camera.main;

        if (IL)
        {
            InputLog = IL.InputLog;
        }

    }

    void Update()
    {
        //currentX += Input.GetAxis("Mouse X");
        if (!IL)
        {
            currentY += Input.GetAxis("Mouse Y");
        }
        else if (IL && ILCounter < InputLog.Count)
        {
            currentY += InputLog[ILCounter].MouseY;
        }


        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

        if(IL)
        {
            ILCounter++;
        }
    }
	
	// Update is called once per frame
	void LateUpdate () {

        //transform.position = Look.position + offsetPosition;

        if (!HadDied)
        {
            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, 0, 0);
            transform.position = lookAt.TransformPoint(rotation * dir) + offset2;
            transform.LookAt(lookAt.position + offset2);
            CurrentLook = lookAt.position + offset2;
        }

    }
}
