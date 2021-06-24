using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quickSelectScreen : MonoBehaviour {

    public Image ButtonTop;
    public GameObject upSelect;
    public GameObject DownSelect;
    public GameObject RightSelect;
    public GameObject LeftSelect;

    Vector3 ButtonTopBasePosition;
    Vector3 SelectBaseScale;

    GameObject descale = null;

	// Use this for initialization
	void Start () {
        ButtonTopBasePosition = ButtonTop.transform.position;
        SelectBaseScale = upSelect.transform.localScale;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ButtonTop.transform.position = ButtonTopBasePosition + new Vector3(0, 10, 0);

            DownSelect.transform.localScale = SelectBaseScale;
            LeftSelect.transform.localScale = SelectBaseScale;
            RightSelect.transform.localScale = SelectBaseScale;

            upSelect.transform.localScale = SelectBaseScale * 1.2f;
            descale = upSelect;
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            ButtonTop.transform.position = ButtonTopBasePosition + new Vector3(0, -10, 0);

            upSelect.transform.localScale = SelectBaseScale;
            LeftSelect.transform.localScale = SelectBaseScale;
            RightSelect.transform.localScale = SelectBaseScale;

            DownSelect.transform.localScale = SelectBaseScale * 1.2f;
            descale = DownSelect;
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            ButtonTop.transform.position = ButtonTopBasePosition + new Vector3(-10, 0, 0);

            upSelect.transform.localScale = SelectBaseScale;
            DownSelect.transform.localScale = SelectBaseScale;
            RightSelect.transform.localScale = SelectBaseScale;

            LeftSelect.transform.localScale = SelectBaseScale * 1.2f;
            descale = LeftSelect;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ButtonTop.transform.position = ButtonTopBasePosition + new Vector3(10, 0, 0);

            upSelect.transform.localScale = SelectBaseScale;
            DownSelect.transform.localScale = SelectBaseScale;
            LeftSelect.transform.localScale = SelectBaseScale;

            RightSelect.transform.localScale = SelectBaseScale * 1.2f;
            descale = RightSelect;
        }
        else
        {
            ButtonTop.transform.position = ButtonTopBasePosition;
            upSelect.transform.localScale = SelectBaseScale;
            DownSelect.transform.localScale = SelectBaseScale;
            LeftSelect.transform.localScale = SelectBaseScale;
            RightSelect.transform.localScale = SelectBaseScale;

        }
    }
}
