using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Image timerUI;
    public int timer = 60;
    public int TimeLimit = 60;
    public int scoreValue;

    public Text score;

	// Use this for initialization
	void Start () {
        score.text = "0000";
        StartCoroutine(StartTimer());
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void AddScore(int Amount)
    {
        scoreValue += Amount;
        string temp = "";
        int numberLength;
        numberLength = scoreValue.ToString().Length;
        for (int i = numberLength; i < 4; i++)
        {
            temp += "0";
        }
        temp += scoreValue.ToString();
        score.text = temp;
    }

    IEnumerator StartTimer()
    {
        while (true)
        {
            timer--;
            timerUI.fillAmount = (1 * ((float)timer / (float)TimeLimit));
            if (timer <= 5)
            {
                timerUI.color = Color.red;
            }
            if (timer == 0)
            {
                timerUI.fillAmount = 0;
                break;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
