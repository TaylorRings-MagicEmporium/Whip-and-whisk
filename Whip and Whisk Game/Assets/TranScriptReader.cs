using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranScriptReader : MonoBehaviour {

    public string ScriptName = "";
    public GameObject MainText;
    public PersonDirector PersonLeft;
    public PersonDirector PersonRight;
    public GameObject PersonLeftSign;
    public GameObject PersonRightSign;

    public Text name_space;
    public string PLName;
    public string PRName;
    //public GameObject SkipButton;

    public bool skip = false;
    public bool PL;
    public bool PR;

    string[] TextFile;
    string line;

    public bool DoneDisplay = false;
    public bool ForwardScript = false;
    // Use this for initialization
    void Start () {
        if(ScriptName != "")
        {
            TextFile = System.IO.File.ReadAllLines(@"D:\Whip-and-Whisk\Whip and Whisk Game\Assets\Scripts\" + ScriptName + ".txt");
            StartCoroutine(TalkingSequence());
        }

	}
	
	void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!DoneDisplay)
            {
                MainText.GetComponent<textSpeech>().FinishDisplay();
                DoneDisplay = true;
            }
            else
            {
                ForwardScript = true;
            }
        }
    }

    IEnumerator TalkingSequence()
    {
        Debug.Log(TextFile.Length);
        //foreach(string line in TextFile)
        for(int counter = 0; counter < TextFile.Length; counter++)
        {
            ForwardScript = false;
            DoneDisplay = false;
            //yield return new WaitForSeconds(1);
            Debug.Log("COUNTER: " + counter);
            line = TextFile[counter];
            Debug.Log(line);

            if (skip)
            {
                skip = false;
                continue;
            }

            if(line.Length == 0)
            {
                continue;
            }

            if(line == "[start]")
            {
                continue;
            } else if(line == "[end]")
            {
                continue;
            }

            if(line == "#PL")
            {
                PersonRight.QuietState();
                PL = true;
                PR = false;
                Debug.Log("PL set!");
                continue;
            }
            else if(line == "#PR")
            {
                PersonLeft.QuietState();
                PL = false;
                PR = true;
                Debug.Log("PR set!");
                continue;
            }

            if (PL)
            {
                name_space.text = PLName;

                PersonLeftSign.SetActive(true);
                PersonRightSign.SetActive(false);
                if (line[0] == '#')
                {
                    //Debug.Log("changed name");
                    //Debug.Log(line);
                    //Debug.Log("TRYING TO ACCESS: " + (counter + 1));
                    //Debug.Log("comparing #name to: " + line + " which equals to: " + (line == "#name"));


                    if (line == "#name")
                    {
                        Debug.Log("changed name");
                        Debug.Log(line);
                        PLName = TextFile[counter + 1];
                        skip = true;
                    } else if (line[1] == 'E')
                    {
                        PersonLeft.SetMaterials(line.Substring(2));
                    } else if(line[1] == 'A')
                    {
                        PersonLeft.SetAnimation(line.Substring(2));
                    }
                    
                    continue;
                }
                else
                {
                    MainText.GetComponent<textSpeech>().SetText(line);
                }

            }
            else
            {

                name_space.text = PRName;

                PersonLeftSign.SetActive(false);
                PersonRightSign.SetActive(true);
                if (line[0] == '#')
                {
                    //Debug.Log("changed name");
                    //Debug.Log(line);
                    //Debug.Log("TRYING TO ACCESS: " + (counter + 1));
                    //Debug.Log("comparing #name to: " + line + " which equals to: " + (line == "#name"));


                    if (line == "#name")
                    { 

                        PRName = TextFile[counter + 1];
                        skip = true;
                    }                  
                    else if (line[1] == 'E')
                    {
                        PersonRight.SetMaterials(line.Substring(2));
                    }
                    else if (line[1] == 'A')
                    {
                        PersonRight.SetAnimation(line.Substring(2));
                    }
                    continue;
                    }
                    else
                    {
                        MainText.GetComponent<textSpeech>().SetText(line);
                    }
            }



            while(ForwardScript == false)
            {
                yield return null;
            }


        }
    }

    public void Done()
    {
        DoneDisplay = true;
    }
}
