using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRecord : MonoBehaviour {

    public string ScriptName;
    private System.IO.StreamWriter sw;

    // Use this for initialization
    void Start () {
        sw = new System.IO.StreamWriter(@"D:\Whip-and-Whisk\Whip and Whisk Game\Assets\Input Recorder\" + ScriptName + ".txt");
	}
	
	// Update is called once per frame
	void Update () {
        sw.Write(Input.GetAxis("Horizontal"));
        sw.Write(" ");
        sw.Write(Input.GetAxis("Vertical"));
        sw.Write(" ");
        sw.Write(Input.GetAxis("Mouse ScrollWheel"));
        sw.Write(" ");
        sw.Write(Input.GetMouseButtonDown(0));
        sw.Write(" ");
        sw.Write(Input.GetKeyDown(KeyCode.Space));
        sw.Write(" ");
        sw.Write(Input.GetAxis("Mouse Y"));
        sw.WriteLine(" ");
    }

    void OnApplicationQuit()
    {
        sw.Close();
    }
}
