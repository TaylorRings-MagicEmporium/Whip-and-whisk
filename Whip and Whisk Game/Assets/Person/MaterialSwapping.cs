using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapping : MonoBehaviour {

    public List<Material> ListOfMaterials;
    public List<Material> ActiveMaterials;

    public float time = 1;

    public string LastState = "";

	// Use this for initialization
	void Start () {
        StartCoroutine(GoThrough());
	}

    IEnumerator GoThrough()
    {
        int pointer = 0;
        while (true)
        {
            if (pointer >= ActiveMaterials.Count)
            {
                pointer = 0;
            }
            GetComponent<SkinnedMeshRenderer>().material = ActiveMaterials[pointer];
            
            pointer++;

            yield return new WaitForSeconds(time);
        }
    }

    public void SetMaterials(string faceName)
    {
        ActiveMaterials = new List<Material>();
        switch (faceName)
        {
            case "helpful":
                ActiveMaterials.Add(ListOfMaterials[10]);
                ActiveMaterials.Add(ListOfMaterials[11]);
                break;
            case "sad":
                ActiveMaterials.Add(ListOfMaterials[12]);
                ActiveMaterials.Add(ListOfMaterials[13]);
                break;
            case "shocked1":
                ActiveMaterials.Add(ListOfMaterials[15]);
                break;
            case "shocked2":
                ActiveMaterials.Add(ListOfMaterials[14]);
                break;
            case "shocked3":
                ActiveMaterials.Add(ListOfMaterials[16]);
                break;
            case "comp":
                ActiveMaterials.Add(ListOfMaterials[4]);
                ActiveMaterials.Add(ListOfMaterials[5]);
                break;
            case "happy":
                ActiveMaterials.Add(ListOfMaterials[8]);
                ActiveMaterials.Add(ListOfMaterials[9]);
                break;
            case "eh":
                ActiveMaterials.Add(ListOfMaterials[6]);
                ActiveMaterials.Add(ListOfMaterials[7]);
                break;
            case "angry":
                ActiveMaterials.Add(ListOfMaterials[0]);
                ActiveMaterials.Add(ListOfMaterials[1]);
                break;
            case "hungry":
                ActiveMaterials.Add(ListOfMaterials[17]);
                ActiveMaterials.Add(ListOfMaterials[18]);
                break;

        }
        GetComponent<SkinnedMeshRenderer>().material = ActiveMaterials[0];
        LastState = faceName;

    }

    public void QuietState()
    {
        if (LastState != "")
        {
            ActiveMaterials = new List<Material>();
            switch (LastState)
            {
                case "helpful":
                    ActiveMaterials.Add(ListOfMaterials[10]);
                    break;
                case "sad":
                    ActiveMaterials.Add(ListOfMaterials[12]);
                    break;
                case "shocked1":
                    ActiveMaterials.Add(ListOfMaterials[15]);
                    break;
                case "shocked2":
                    ActiveMaterials.Add(ListOfMaterials[14]);
                    break;
                case "shocked3":
                    ActiveMaterials.Add(ListOfMaterials[16]);
                    break;
                case "comp":
                    ActiveMaterials.Add(ListOfMaterials[4]);
                    break;
                case "happy":
                    ActiveMaterials.Add(ListOfMaterials[8]);
                    break;
                case "eh":
                    ActiveMaterials.Add(ListOfMaterials[6]);
                    break;
                case "angry":
                    ActiveMaterials.Add(ListOfMaterials[0]);
                    break;
                case "hungry":
                    ActiveMaterials.Add(ListOfMaterials[17]);
                    break;
            }
            GetComponent<SkinnedMeshRenderer>().material = ActiveMaterials[0];
            
        }

    }
}
