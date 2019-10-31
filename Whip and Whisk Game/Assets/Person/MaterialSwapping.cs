using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapping : MonoBehaviour {

    public List<Material> ListOfMaterials;

	// Use this for initialization
	void Start () {
        StartCoroutine(GoThrough());
	}

    IEnumerator GoThrough()
    {
        int pointer = 0;
        while (true)
        {
            GetComponent<SkinnedMeshRenderer>().material = ListOfMaterials[pointer];
            pointer++;
            if(pointer == ListOfMaterials.Count)
            {
                pointer = 0;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
