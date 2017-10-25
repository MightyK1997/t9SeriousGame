using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeImageScript : MonoBehaviour {

    // Use this for initialization

    GameObject myButton;
    GameObject go;
    public Texture myTexture;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        myButton = GameObject.Find("Button");
        myButton.GetComponent<Button>().onClick.AddListener(TaskToDo);
	}

    void TaskToDo()
    {
        go = GameObject.Find("Plane");
        go.GetComponent<Renderer>().material.mainTexture = myTexture;
    }
}
