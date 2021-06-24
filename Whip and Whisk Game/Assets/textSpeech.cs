using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class textSpeech : MonoBehaviour {

    Text MainText;
    public float speed = 1;
    public string speak = "";
    public bool pause = false;

    public int counter;

    Coroutine TalkFunction;

    public TranScriptReader TSR;
	// Use this for initialization
	void Start () {
        MainText = GetComponent<Text>();
        MainText.text = "";
        //TalkFunction = StartCoroutine(talk());
        //artCoroutine(talk());
	}

    IEnumerator talk()
    {
        counter = 0;
        while (true)
        {
            if(counter != speak.Length && !pause)
            {
                MainText.text += speak[counter];
                counter++;
            } else if(counter >= speak.Length)
            {
                break;
            }

            yield return new WaitForSeconds(1 / speed);
        }
        if (TSR)
        {
            TSR.Done();
        }
        TalkFunction = null;

    }

    public void SetText(string text)
    {
        if(TalkFunction != null)
        {
            StopCoroutine(TalkFunction);
            TalkFunction = null;
        }
        MainText.text = "";
        speak = text;
        TalkFunction = StartCoroutine(talk());
    }

    public void FinishDisplay()
    {
        if(TalkFunction != null)
        {
            StopCoroutine(TalkFunction);
        }
        MainText.text = speak;
    }
}
