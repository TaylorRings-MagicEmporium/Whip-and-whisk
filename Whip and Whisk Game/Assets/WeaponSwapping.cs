using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwapping : MonoBehaviour {

    public List<Sprite> foodPlaceholders;
    public List<GameObject> foodPlaceholderObjects;

    public Image FoodImage;

    public Animator person;

    public int WeaponCounter = 0;

    private InputLoader IL;
    private int ILCounter;
    float w;

    private List<InputLine> InputLog = new List<InputLine>();

    // Use this for initialization
    void Start () {
        IL = GetComponent<InputLoader>();
        if (IL)
        {
            InputLog = IL.InputLog;
        }
    }

    // Update is called once per frame
    void Update() {
        if (!IL)
        {
            w = Input.GetAxis("Mouse ScrollWheel");
        }
        else
        {
            if(ILCounter < InputLog.Count)
            {
                w = IL.InputLog[ILCounter].MouseWheel;
                ILCounter++;
            }

        }


        if (w > .1f)
        {
            //scroll up
            WeaponCounter++;
        } else if (w < -.1f)
        {
            //scroll down
            WeaponCounter--;
        }

        if (WeaponCounter == foodPlaceholders.Count)
        {
            WeaponCounter = 0;
        } else if (WeaponCounter == -1)
        {
            WeaponCounter = foodPlaceholders.Count - 1;
        }

        if (foodPlaceholderObjects[WeaponCounter].CompareTag("Gun"))
        {
            person.SetBool("HasGun", true);
        } else
        {
            person.SetBool("HasGun", false);
        }
        if (FoodImage)
        {
            FoodImage.sprite = foodPlaceholders[WeaponCounter];
        }

        foreach(GameObject g in foodPlaceholderObjects)
        {
            g.SetActive(false);
        }
        foodPlaceholderObjects[WeaponCounter].SetActive(true);
	}
}
