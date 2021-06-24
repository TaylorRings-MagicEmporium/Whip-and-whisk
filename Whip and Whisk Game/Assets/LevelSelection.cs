using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour {

    public List<Vector3> RectPositions;
    public List<int> starAmounts;
    public List<string> levelWhich;
    public List<string> levelType;
    public List<string> levelName;
    //Animator ani;

    //public List<int> Rotate;

    public int counter;
    public GameObject text;
    public GameObject stars;
    // Use this for initialization
    void Start () 
    {
        //ani = GetComponent<Animator>();
        transform.Rotate(new Vector3(0, 0, -180));
        text.transform.Rotate(new Vector3(0, 0, -180));
        stars.transform.Rotate(new Vector3(0, 0, -180));
        stars.transform.localPosition = new Vector3(0, 77, 0);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            counter++;
            if (counter == RectPositions.Count)
            {
                return;
            }



            //ani.SetTrigger("play");
            if (counter == 1)
            {
                transform.Rotate(new Vector3(0, 0, -180));
                text.transform.Rotate(new Vector3(0, 0, -180));
                stars.transform.localPosition = new Vector3(0, -57, 0);
                stars.transform.Rotate(new Vector3(0, 0, -180));
            }


        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            counter--;
            if (counter == -1)
            {
                return;
            }


            //ani.SetTrigger("play");
            if (counter == 0)
            {
                transform.Rotate(new Vector3(0, 0, -180));
                text.transform.Rotate(new Vector3(0, 0, -180));
                stars.transform.localPosition = new Vector3(0, 77, 0);
                stars.transform.Rotate(new Vector3(0, 0, -180));
            }


        }

        GetComponent<RectTransform>().anchoredPosition = new Vector2(RectPositions[counter].x, RectPositions[counter].y);
        text.GetComponent<Text>().text = levelWhich[counter] + "\n" + levelType[counter] + "\n" + levelName[counter];
        stars.GetComponent<StarThing>().SetStars(starAmounts[counter]);

        //transform.position = RectPositions[counter];
        //transform.Rotate(0, 0, Rotate[counter]);


    }
}
