﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shakeTheBooty : MonoBehaviour {

    // Use this for initialization

    GameObject myButton;
    Camera camera;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        myButton = GameObject.Find("TestButton");
        myButton.GetComponent<Button>().onClick.AddListener(middleFunction);
    }

    void middleFunction()
    {
        StartCoroutine(TaskToDo());
    }

    IEnumerator TaskToDo()
    {
        camera = Camera.main;
        for (int i = 0; i < 10; i++)
        {
            camera.transform.position = new Vector3(0.5f, 1, -30);
            yield return new WaitForSeconds(0.02f);
            camera.transform.position = new Vector3(0.1f, 1, -30);
            yield return new WaitForSeconds(0.02f);
            camera.transform.position = new Vector3(0.5f, 1, -30);
            yield return new WaitForSeconds(0.02f);
            camera.transform.position = new Vector3(0, 1, -30);
            yield return new WaitForSeconds(0.02f);
            camera.transform.position = new Vector3(-0.5f, 1, -30);
            yield return new WaitForSeconds(0.02f);
            camera.transform.position = new Vector3(-1f, 1, -30);
            yield return new WaitForSeconds(0.02f);
            camera.transform.position = new Vector3(-0.5f, 1, -30);
            yield return new WaitForSeconds(0.02f);
            camera.transform.position = new Vector3(0, 1, -30);
        }
    }
}
