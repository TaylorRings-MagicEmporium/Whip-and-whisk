using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eggTimerRotator : MonoBehaviour {

    // Use this for initialization
    public int TimeLimit = 60;
    public int timer;

    public Image TimerUI;

    Color color;

    public 

	void Start () {
        timer = TimeLimit;
        StartCoroutine(EggTimer());
        color = TimerUI.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator EggTimer()
    {
        while (true)
        {
            timer--;
            transform.Rotate(new Vector3(0, 0, 360 / TimeLimit));
            TimerUI.fillAmount = (1 * ((float)timer / (float)TimeLimit));
            if(timer <= 5)
            {
                TimerUI.color = Color.red;
            }
            if(timer == 0)
            {
                TimerUI.fillAmount = 0;
                break;
            }
            yield return new WaitForSeconds(1);
        }
        //TimerUI.fillAmount = 0;

        int countLimit = 150;
        int counter = 0;

        int randValue = 0;

        Vector3 BasePosition = transform.position;

        while (true)
        {
            if(counter == countLimit)
            {
                break;
            }

            transform.position = BasePosition;
            transform.position = Vector3.Lerp(BasePosition, BasePosition + new Vector3(Random.Range(3, 10), Random.Range(3, 10), Random.Range(3, 10)), Time.deltaTime*4);
            //transform.position += );
            counter++;
            yield return new WaitForEndOfFrame();
            
        }
        transform.position = BasePosition;
    }
}
