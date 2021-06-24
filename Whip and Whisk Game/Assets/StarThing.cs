using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarThing : MonoBehaviour {

    public Image star1;
    public Image star2;
    public Image star3;

	// Use this for initialization
	void Start () {
		
	}

    public void SetStars(int amount)
    {
        if(amount == 0)
        {
            star1.color = Color.white;
            star2.color = Color.white;
            star3.color = Color.white;
        }
        else if(amount == 1)
        {
            star1.color = Color.yellow;
            star2.color = Color.white;
            star3.color = Color.white;
        } else if(amount == 2)
        {
            star1.color = Color.yellow;
            star2.color = Color.yellow;
            star3.color = Color.white;
        } else if(amount == 3)
        {
            star1.color = Color.yellow;
            star2.color = Color.yellow;
            star3.color = Color.yellow;
        }
    }
}
