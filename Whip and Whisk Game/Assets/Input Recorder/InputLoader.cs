using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct InputLine
{
    public float Horizontal;
    public float Vertical;
    public float MouseWheel;
    public bool MouseClick0;
    public bool space;
    public float MouseY;
}

public class InputLoader : MonoBehaviour {

    public string ScriptName = "";
    public List<InputLine> InputLog = new List<InputLine>();

	// Use this for initialization
	void Awake () {
        string temp = "";
        int counter = 0;
        InputLine tempInput;
        var fmt = new System.Globalization.NumberFormatInfo();
        fmt.NegativeSign = "-";
        foreach (string line in System.IO.File.ReadAllLines(@"D:\Whip-and-Whisk\Whip and Whisk Game\Assets\Input Recorder\" + ScriptName + ".txt"))
        {
            temp = "";
            counter = 0;
            tempInput = new InputLine();
            foreach (char c in line)
            {
                if(c != ' ')
                {
                    temp += c;
                }
                else
                {
                    //Debug.Log("in loop: " + temp);
                    if(counter == 0)
                    {
                        tempInput.Horizontal = float.Parse(temp, fmt);
                    } else if(counter == 1)
                    {
                        tempInput.Vertical = float.Parse(temp, fmt);
                    } else if(counter == 2)
                    {
                        tempInput.MouseWheel = float.Parse(temp, fmt);
                    }else if(counter == 3)
                    {
                        if(temp == "True")
                        {
                            tempInput.MouseClick0 = true;
                        } else
                        {
                            tempInput.MouseClick0 = false;
                        }

                    }else if(counter == 4)
                    {
                        if(temp == "True")
                        {
                            tempInput.space = true;
                        }
                        else
                        {
                            tempInput.space = false;
                        }
                        
                    } else if(counter == 5)
                    {
                        tempInput.MouseY = float.Parse(temp, fmt);
                    }
                    counter++;
                    temp = "";
                }

            }

            InputLog.Add(tempInput);

        }

        //foreach(InputLine il in InputLog)
        //{
        //    Debug.Log(il.Horizontal + " " + il.Vertical + " " + il.MouseWheel + " " + il.MouseClick0 + " " + il.space);
        //}
    }
	
}
