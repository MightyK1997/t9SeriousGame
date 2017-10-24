using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthCalc : MonoBehaviour {

    public static string houseHealth = "500";
    int blockHealth = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void buttonClicked()
    {
        GameObject roof = GameObject.FindGameObjectWithTag("roof");
        GameObject foundation = GameObject.FindGameObjectWithTag("foundation");
        GameObject wall1 = GameObject.FindGameObjectWithTag("wall");
        GameObject wall2 = GameObject.FindGameObjectWithTag("extra");
        GameObject support = GameObject.FindGameObjectWithTag("support");

        if (roof.activeSelf && foundation.activeSelf && wall1.activeSelf && wall2.activeSelf && support.activeSelf)
        {
            blockHealth -= 50;
            houseHealth = (5 * blockHealth).ToString();
        }
    }
}
