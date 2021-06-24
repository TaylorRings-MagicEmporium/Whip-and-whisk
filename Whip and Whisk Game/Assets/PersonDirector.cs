using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonDirector : MonoBehaviour {

    Animator Person;
    public MaterialSwapping MS;
    //StateMachineBehaviour SMB;

	// Use this for initialization
	void Awake () {
        Person = GetComponent<Animator>();
        Person.SetInteger("AnimationState", -1);
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Person.SetInteger("AnimationState", -1);
    }


    public void SetMaterials(string word)
    {
        if (word == "helpful")
        {
            MS.SetMaterials("helpful");
        }
        else if (word == "sad")
        {
            MS.SetMaterials("sad");
        }
        else if (word == "shocked1")
        {
            MS.SetMaterials("shocked1");
        }
        else if (word == "shocked2")
        {
            MS.SetMaterials("shocked2");
        }
        else if (word == "shocked3")
        {
            MS.SetMaterials("shocked3");
        }
        else if (word == "happy")
        {
            MS.SetMaterials("happy");
        }
        else if (word == "angry")
        {
            MS.SetMaterials("angry");
        }
        else if (word == "eh")
        {
            MS.SetMaterials("eh");
        }
        else
        {
            MS.SetMaterials("comp");
        }
    }

    public void SetAnimation(string word)
    {
        if(word == "bigArmsDrastic")
        {
            Person.SetInteger("AnimationState", 0);
        }
        else if (word == "bigArmsNormal")
        {
            Person.SetInteger("AnimationState", 1);
        }
        else if (word == "disappointed")
        {
            Person.SetInteger("AnimationState", 2);
        }
        else if (word == "phoneBeginning")
        {
            Person.SetInteger("AnimationState", 3);
        }
        else if (word == "phoneDrastic")
        {
            Person.SetInteger("AnimationState", 4);
        }
        else if (word == "phoneNormal")
        {
            Person.SetInteger("AnimationState", 5);
        }
        else if (word == "phoneQuiet")
        {
            Person.SetInteger("AnimationState", 6);
        }
        else if (word == "questionDrastic")
        {
            Person.SetInteger("AnimationState", 7);
        }
        else if (word == "questionNormal")
        {
            //Debug.Log("SETTING IT");
            Person.SetInteger("AnimationState", 8);
        }
        else if (word == "sassyDrastic")
        {
            Person.SetInteger("AnimationState", 9);
        }
        else if (word == "sassyNormal")
        {
            Person.SetInteger("AnimationState", 10);
        }
        else if (word == "sassyWalk")
        {
            Person.SetInteger("AnimationState", 11);
        }
        else if (word == "sittingNormal")
        {
            Person.SetInteger("AnimationState", 12);
        }
        else if (word == "sittingRelaxed")
        {
            Person.SetInteger("AnimationState", 13);
        }
        else if (word == "sittingTalking")
        {
            Person.SetInteger("AnimationState", 14);
        }
    }

    public void QuietState()
    {
        MS.QuietState();
    }

    void OnStateExit()
    {
        Person.SetInteger("AnimationState", -1);
    }

}
