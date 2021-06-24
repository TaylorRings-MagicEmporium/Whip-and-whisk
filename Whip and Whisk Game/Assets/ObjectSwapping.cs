using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwapping : MonoBehaviour {

    public List<GameObject> food = new List<GameObject>();

	// Use this for initialization
	void Start () {
		foreach(Transform child in transform)
        {
            food.Add(child.gameObject);
        }

        foreach (GameObject g in food)
        {
            g.SetActive(false);
        }

        StartCoroutine(SwitchFood());
    }

    IEnumerator SwitchFood()
    {
        int counter = 0;

        while (true)
        {
            food[counter].SetActive(true);
            if(counter == 0)
            {
                food[food.Count - 1].SetActive(false);
            }
            else
            {
                food[counter - 1].SetActive(false);
            }


            yield return new WaitForSeconds(1);
            counter++;
            if(counter == food.Count)
            {
                counter = 0;
            }
        }
    }
}
